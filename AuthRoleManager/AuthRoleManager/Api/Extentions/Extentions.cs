using AuthRoleManager.Infrastructures;
using AuthRoleManager.Infrastructures.Interface;
using AuthRoleManager.Infrastructures.Repositories;
using AuthRoleManager.Services;
using AuthRoleManager.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;

namespace AuthRoleManager.Api.Extentions;

public static class Extentions
{
    public static void ConfigureDbContexts(this IServiceCollection serviceCollection,
        ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<AppDataContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configurationManager.GetConnectionString("DefaultConnectionString"));
        });
    }
    public static void ConfigureRepositories(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddSingleton<SmtpClient>(provider =>
        {
            var username = configurationManager.GetSection("SMTP:Username").Get<string>();
            var password = configurationManager.GetSection("SMTP:Password").Get<string>();
            var host = configurationManager.GetSection("SMTP:Host").Get<string>();
            var port = configurationManager.GetSection("SMTP:Port").Get<int>();
            NetworkCredential myCredential = new NetworkCredential(username, password);
            var client = new SmtpClient();
            client.Host = host;
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = myCredential;
            client.EnableSsl = true;

            return client;
        });

        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IHeshService,HeshService>();
        services.AddScoped<IOTPService,OTPService>();
        services.AddScoped<ITokenService,TokenSevice>();
        services.AddScoped<IEmailService,EmailService>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<IAuthService,AuthService>();
    }
}
