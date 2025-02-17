using AuthRoleManager.Services.Interface;
using System.Security.Cryptography;
using System.Text;

namespace AuthRoleManager.Services;

public class HeshService : IHeshService
{
    public  async Task<string> HeshClientPasswordAsync(string password)
    {
        using(SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();

            foreach(byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
