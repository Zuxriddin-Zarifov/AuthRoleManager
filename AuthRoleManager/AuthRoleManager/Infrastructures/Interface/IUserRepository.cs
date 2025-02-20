using AuthRoleManager.Domain.Entity;

namespace AuthRoleManager.Infrastructures.Interface;

public interface IUserRepository : IRepositoryBase<User>
{
    public Task<User> GetByEmailPassword(string email, string password);
}
