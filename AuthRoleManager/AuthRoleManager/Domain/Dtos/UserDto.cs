﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthRoleManager.Domain.Dtos;

public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string OTP { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required, StringLength(16, MinimumLength = 8)] public string Password { get; set; }
}
