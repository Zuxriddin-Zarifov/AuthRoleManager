﻿using AuthRoleManager.Domain.Enum;

namespace AuthRoleManager.Services.Interface;

public interface ITokenService
{
    public Task<string> GetTokenAsync(string email, string firstName, Role role); 
}
