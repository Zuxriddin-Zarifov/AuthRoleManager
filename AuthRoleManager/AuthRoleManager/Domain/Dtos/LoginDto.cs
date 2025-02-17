using System.ComponentModel.DataAnnotations;

namespace AuthRoleManager.Domain.Dtos;

public class LoginDto
{
    [Required, EmailAddress] public string Email { get; set; }
    [Required, StringLength(16, MinimumLength = 8)] public string Password { get; set; }
    [Compare("Password", ErrorMessage = "Parollar mos kelmaydi.")] public string ConfirmPassword { get; set; }
}
