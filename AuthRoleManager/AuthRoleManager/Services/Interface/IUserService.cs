using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;

namespace AuthRoleManager.Services.Interface;

public interface IUserService
{
    public ValueTask<User> CreateAsync(UserDto userDto);
    public ValueTask<User> GetByIdAsync(long id);
}
