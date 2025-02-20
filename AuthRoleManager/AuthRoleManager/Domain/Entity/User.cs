using AuthRoleManager.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthRoleManager.Domain.Entity;

[Table("users",Schema ="auth_role_manager")]
[Index(nameof(Email), IsUnique = true)]
public class User : ModelBase
{
   [Column("first_name")] public string FirstName { get; set; }
   [Column("last_name")] public string LastName { get; set; }
   [Column("email"),Required,EmailAddress] public string Email { get; set; }
   [Column("password")] public string Password { get; set; }
   [Column("otp")] public string OTP { get; set; }
   [Column("otp_live_detetime")] public DateTime OTPLiveDatetime { get; set; }
   [Column("role")] public Role Role { get; set; } = Role.User;
}
