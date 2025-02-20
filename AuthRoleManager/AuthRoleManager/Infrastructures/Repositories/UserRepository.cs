using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Infrastructures.Interface;

namespace AuthRoleManager.Infrastructures.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDataContext appDataContext) : base(appDataContext)
        {
        }

        public async Task<User> GetByEmailPassword(string email, string password)
        {
            var result = await GetAllAsync();

            return result.FirstOrDefault(user => user.Email == email && user.Password == password);
        }

    }
}
