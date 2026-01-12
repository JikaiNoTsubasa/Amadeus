using System;
using amadeus_api.job_models;
using amadeus_api.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amadeus_api.job_controllers;

[AllowAnonymous]
public class AuthController (AuthService authService, HashService hashService) : AmaController
{
    private readonly AuthService _authService = authService;
    private readonly HashService _hashService = hashService;

    [HttpPost]
    [Route("api/auth/login")]
    public IActionResult Login([FromBody] RequestLogin model)
    {
        return Ok();
    }
}
