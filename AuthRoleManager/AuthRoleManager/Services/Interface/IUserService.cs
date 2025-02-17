using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;

namespace AuthRoleManager.Services.Interface;

public interface IUserService
{
    public Task<User> CreateAsync(UserDto userDto);
    public Task<User> GetByIdAsync(long id);
    public Task<User> GetByEmailPasswordAsync(string email, string password);
}
