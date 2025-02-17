namespace AuthRoleManager.Services.Interface;

public interface IEmailService
{
    public Task SendMassageAsync(string email, string subject, string body);

}
