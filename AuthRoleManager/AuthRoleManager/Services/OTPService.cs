using AuthRoleManager.Services.Interface;

namespace AuthRoleManager.Services;

public class OTPService : IOTPService
{
    private Random _random;
    public OTPService(Random random)
    {
        _random = random;
    }
    public async Task<string> GenerateOTPAsync()
    {
        var otp = _random.Next(1000000, 9999999)/10;

        return otp.ToString();
    }
}
