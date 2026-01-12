using System;
using amadeus_api.job_managers;
using amadeus_api.job_models;
using amadeus_api.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amadeus_api.job_controllers;

[AllowAnonymous]
public class AuthController (AuthService authService, HashService hashService, AuthManager authManager) : AmaController
{
    private readonly AuthService _authService = authService;
    private readonly HashService _hashService = hashService;
    private readonly AuthManager _authManager = authManager;

    [HttpPost]
    [Route("api/auth/login")]
    public IActionResult Login([FromBody] RequestLogin model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        ResponseLogin response = _authManager.LoginUserToApi(model.Identifier, model.Password);
        return StatusCode(200, response);
    }
}
