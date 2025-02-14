namespace AuthRoleManager.Services.Interface;

public interface IHeshService
{
    public Task<string> HashFunctionAsync(string password);
}
