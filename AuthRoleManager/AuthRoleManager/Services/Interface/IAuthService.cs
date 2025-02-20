using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;

namespace AuthRoleManager.Services.Interface;

public interface IAuthService
{
    public Task<string> RegistrationAsync(UserCreateDto dto);
    public Task<User> LoginAsync(LoginDto dto);
    public Task<bool> CheckEmailAsync( string otp,string email,string password);
}
