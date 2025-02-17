using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;

namespace AuthRoleManager.Services.Interface;

public interface IAuthService
{
    public Task<string> RegistrationAsync(UserDto dto);
    public Task<User> LoginAsync(LoginDto dto);
    public Task<bool> CheckEmail(string email, string opt);
}
