namespace AuthRoleManager.Domain;

public static class Settings
{
    public static string Subject = "OTP auth role manager project";
    public static string Body(string otp)
    {
       return $"Your OTP is: {otp}. Do not share this code with anyone. It is valid for 5 minutes.";
    }
}
