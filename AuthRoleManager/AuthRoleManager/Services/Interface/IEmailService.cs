namespace AuthRoleManager.Services.Interface;

public interface IEmailService
{
    public Task SendMassageAsync(string email);
    public Task<bool> CheckEmailAsync(string email, string otp);

}
