using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthRoleManager.Api.Controllers;

[Controller, Route("auth")]
public class AuthController
{
    private  IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("registration"), AllowAnonymous]
    public async Task<string> RegistrationAsync(UserCreateDto userDto)
    {
        return await _authService.RegistrationAsync(userDto);
    }

    [HttpPost("login"),AllowAnonymous]
    public async Task<User> LoginAsync(LoginDto loginDto)
    {
        return await _authService.LoginAsync(loginDto);
    }

    [HttpGet("check_email"),AllowAnonymous]
    public async Task<bool> CheckEmailAsync(string email,string password, string otp)
    {
        return await _authService.CheckEmailAsync(otp,email,password);
    }

}

