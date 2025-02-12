using AuthRoleManager.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace AuthRoleManager.Domain.Entity
{
    public class User : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; } = Role.User;
    }
}
