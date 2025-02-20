using AuthRoleManager.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthRoleManager.Domain.Dtos;

public class UserUpdateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required, StringLength(16, MinimumLength = 8)] public string Password { get; set; }
    [Compare("Password", ErrorMessage = "Parollar mos kelmaydi.")] public string ConfirmPassword { get; set; }
    public Role Role { get; set; }
}
