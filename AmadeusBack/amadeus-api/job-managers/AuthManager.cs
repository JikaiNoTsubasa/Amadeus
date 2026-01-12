using System;
using amadeus_api.database;
using amadeus_api.exceptions;
using amadeus_api.services;

namespace amadeus_api.job_managers;

public class AuthManager(AmaContext dbContext, HashService hashService, AuthService authService) : AmaManager(dbContext)
{
    private readonly HashService _hashService = hashService;
    private readonly AuthService _authService = authService;

    public void LoginUserToApi(string identifier, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email.ToLower().Equals(identifier.ToLower())) ?? throw new LoginException("User identifier invalid.");
        if (!user.CanLogin)
        {
            throw new LoginException("User is not allowed to login.");
            
        }

        if (!_hashService.VerifyPassword(password, user.PasswordHash))
        {
            throw new LoginException("Password is incorrect.");
        }

        int expirationHours = 1;
        var token = _authService.GenerateToken(user, expirationHours);

        user.LastConnection = DateTime.UtcNow;
        _context.SaveChanges();
    }
}
