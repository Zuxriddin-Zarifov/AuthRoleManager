using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;

namespace AuthRoleManager.Services.Interface;

public interface IUserService
{
    public Task<User> CreateAsync(UserCreateDto userDto);
    public Task<User> DeleteAsync(long id);
    public Task<User> UpdateAsync(UserUpdateDto userDto);
    public Task<User> GetByIdAsync(long id);
    public Task<IEnumerable<User>> GetByAllAsync();
    public Task<User> GetByEmailPasswordAsync(string email, string password);
}
