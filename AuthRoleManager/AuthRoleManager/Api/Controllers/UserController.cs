using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Services;
using AuthRoleManager.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthRoleManager.Api.Controllers;

[Controller, Route("user")]
public class UserController
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("create")]
    //[Authorize]
    public async Task<User> CreateAsync(UserCreateDto createDto)
         => await _userService.CreateAsync(createDto);
    
    [HttpDelete("delete")]
   // [Authorize]
    public async Task<User> DeleteAsync(long id)
        => await _userService.DeleteAsync(id);
    
    [HttpPut("update")]
   // [Authorize]
    public async Task<User> UpdateAsync(UserUpdateDto updateDto)    
        => await _userService.UpdateAsync(updateDto);

    [HttpGet("get_all")]
   // [Authorize]
    public async Task<IEnumerable<User>> GetUsersAsync()
        => await _userService.GetByAllAsync();

    [HttpGet("get_by_id")]
   // [Authorize]
    public async Task<User> GetByIbAsync(long id)   
        => await _userService.GetByIdAsync(id);
    
    [HttpGet("get_by_email_password")]
   // [Authorize]
    public async Task<User> GetByEmailPasswordAsync(string email,string password) 
        => await _userService.GetByEmailPasswordAsync(email, password);
    
}
