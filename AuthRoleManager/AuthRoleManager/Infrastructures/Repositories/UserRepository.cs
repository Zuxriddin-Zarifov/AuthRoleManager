using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Infrastructures.Interface;

namespace AuthRoleManager.Infrastructures.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDataContext appDataContext) : base(appDataContext)
        {
        }
    }
}
