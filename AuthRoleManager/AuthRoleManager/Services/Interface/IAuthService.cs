using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;

namespace AuthRoleManager.Services.Interface;

public interface IAuthService
{
    public Task<User> RegistrationAsync(UserDto dto);
    public Task<User> LoginAsync(UserDto dto);
}
