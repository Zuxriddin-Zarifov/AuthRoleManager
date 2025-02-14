namespace AuthRoleManager.Services.Interface;

public interface ITokenService
{
    public ValueTask<string> GetTokenAsync(string email, string password); 
}
