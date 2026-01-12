using System;
using amadeus_api.database;
using amadeus_api.exceptions;
using amadeus_api.job_models;
using amadeus_api.services;
using log4net;

namespace amadeus_api.job_managers;

public class AuthManager(AmaContext dbContext, HashService hashService, AuthService authService) : AmaManager(dbContext)
{
    private readonly HashService _hashService = hashService;
    private readonly AuthService _authService = authService;
    private static readonly ILog log = LogManager.GetLogger(typeof(AuthManager));

    public ResponseLogin LoginUserToApi(string identifier, string password)
    {
        log.Info("Login attempt for user identifier: " + identifier);
        var user = _context.Users.FirstOrDefault(u => u.Email.ToLower().Equals(identifier.ToLower())) ?? throw new LoginException("User identifier invalid.");
        if (!user.CanLogin)
        {
            log.Error("Login attempt failed: User is not allowed to login. Identifier: " + identifier);
            throw new LoginException("User is not allowed to login.");
        }

        if (!_hashService.VerifyPassword(password, user.PasswordHash))
        {
            log.Error("Login attempt failed: Incorrect password for identifier: " + identifier);
            throw new LoginException("Password is incorrect.");
        }

        int expirationHours = 1;
        var token = _authService.GenerateToken(user, expirationHours);

        user.LastConnection = DateTime.UtcNow;
        _context.SaveChanges();

        log.Info("Login successful for user identifier: " + identifier + ". Token generated with " + expirationHours + " hour(s) expiration.");

        return new ResponseLogin
        {
            Token = token
        };
    }
}
