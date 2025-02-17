namespace AuthRoleManager.Services.Interface;

public interface IHeshService
{
    public Task<string> HeshClientPasswordAsync(string password);
}
