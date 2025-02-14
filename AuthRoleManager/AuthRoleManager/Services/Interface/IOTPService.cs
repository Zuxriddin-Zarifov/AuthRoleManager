namespace AuthRoleManager.Services.Interface;

public interface IOTPService
{
    public Task<string> GenerateOTPAsync();
    
}
