using AuthRoleManager.Domain;
using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Domain.Enum;
using AuthRoleManager.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop.Infrastructure;

namespace AuthRoleManager.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;
    private readonly IHeshService _heshService;
    private readonly IOTPService _oTPService;

    public AuthService(IUserService userService, 
                       IEmailService emailService,     
                       ITokenService tokenService,
                       IHeshService heshService,
                       IOTPService oTPService)
    {
        _userService = userService;
        _emailService = emailService;
        _tokenService = tokenService;
        _heshService = heshService;
        _oTPService = oTPService;
    }
    public async Task<bool> CheckEmailAsync(string otp,string email, string password)
    {
        var user = await _userService.GetByEmailPasswordAsync(email, password);
        if (user is null)
            throw new Exception("user not found");
        if (user.OTP == otp && user.OTPLiveDatetime > DateTime.UtcNow)
            return true;
        else
        {
            await _userService.DeleteAsync(user.Id);
            return false;
        }
        
    }

    public async Task<User> LoginAsync(LoginDto dto)
    {
        var user = await _userService.GetByEmailPasswordAsync(dto.Email, dto.Password);
        return user;
    }

   public async  Task<string> RegistrationAsync(UserCreateDto dto)
    {
        var user =  await _userService.CreateAsync(dto);
        await _emailService.
            SendMassageAsync(user.Email,
                             Settings.Subject,
                             Settings.Body(user.OTP));

        var token = await _tokenService.GetTokenAsync(user.Email, user.FirstName,Role.Admin);
        return token;
    }
}
