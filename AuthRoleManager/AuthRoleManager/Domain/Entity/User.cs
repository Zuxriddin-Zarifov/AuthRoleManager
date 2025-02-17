using AuthRoleManager.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthRoleManager.Domain.Entity;

[Table("users",Schema ="auth_role_manager")]
public class User : ModelBase
{
   [Column("first_name")] public string FirstName { get; set; }
   [Column("last_name")] public string LastName { get; set; }
   [Column("email")] public string Email { get; set; }
   [Column("password")] public string Password { get; set; }
   [Column("role")] public Role Role { get; set; } = Role.User;
}
