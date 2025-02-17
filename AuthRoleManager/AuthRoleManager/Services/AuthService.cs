using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Domain.Enum;
using AuthRoleManager.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace AuthRoleManager.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;
    private readonly IHeshService _heshService;

    public AuthService(IUserService userService, 
                       IEmailService emailService,     
                       ITokenService tokenService,
                       IHeshService heshService)
    {
        _userService = userService;
        _emailService = emailService;
        _tokenService = tokenService;
        _heshService = heshService;
    }
    public async Task<bool> CheckEmail(string email, string opt)
    {
        throw new NotImplementedException();
    }

    public async Task<User> LoginAsync(LoginDto dto)
    {
        var heshPassword = await _heshService.HeshClientPasswordAsync(dto.Password);
        var user = await _userService.GetByEmailPasswordAsync(dto.Email, heshPassword);
        return user;
    }

   public async  Task<string> RegistrationAsync(UserDto dto)
    {
        var user =  await _userService.CreateAsync(dto);
        var token = await _tokenService.GetTokenAsync(user.Email, user.Password,Role.User);
        return token;
    }
}
