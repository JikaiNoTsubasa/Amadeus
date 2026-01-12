using amadeus_api.global;
using log4net;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using amadeus_api.database;
using amadeus_api.services;
using amadeus_api.job_managers;
using amadeus_api.database.models;

var builder = WebApplication.CreateBuilder(args);

// Add log4net
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net("log4net.config");

// Exception handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails(); // Required

ILog log = LogManager.GetLogger(typeof(Program));

builder.Services.AddDbContext<AmaContext>();
builder.Services.AddScoped<HashService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<AmaManager>();
builder.Services.AddScoped<AuthManager>();

builder.Services.AddControllers(o => {
        o.ModelBinderProviders.Insert(0, new UTCDateTimeBinderProvider());
    })
    .AddNewtonsoftJson(options => {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        // options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.;
        // options.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Disables the string conversions from empty to null
builder.Services.AddMvc().AddMvcOptions(options => options.ModelMetadataDetailsProviders.Add(new CustomMetadataProvider()));

// Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

// Disable CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
//app.UseHttpsRedirection();

/*
using var scope = app.Services.CreateScope();
var hashService = scope.ServiceProvider.GetRequiredService<HashService>();
var context = scope.ServiceProvider.GetRequiredService<AmaContext>();
context.Database.EnsureCreated();
User user = new()
{
    Email = "stephane.biehler.priv@gmail.com",
    Name = "Stéphane Biehler Hertzog",
    CanLogin = true,
    PasswordHash = hashService.HashPassword("sbiuserS88"),
    CreatedAt = DateTime.UtcNow
};
context.Users.Add(user);
context.SaveChanges();
*/

log.Info("Amadeus API started.");
app.Run();

