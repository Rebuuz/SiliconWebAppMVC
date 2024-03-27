using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;

public class PasswordHasher
{
    public static (string, string) GenerateSecurePassword(string password)
    {
        using var hmac = new HMACSHA512();
        //unlock password
        var securityKey = hmac.Key;
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        return (Convert.ToBase64String(securityKey), Convert.ToBase64String(hash));
    }

    ///validate secure password
    ///

    public static bool ValidateSecurePassword(string password, string confirmPassword, string securityKey)
    {
        var security = Convert.FromBase64String(securityKey);
        var pwd = Convert.FromBase64String(confirmPassword);

        using var hmac = new HMACSHA512(security);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        ///check if password and confirm password is identical
        for(var i = 0; i < hash.Length; i++)
        {
            if (hash[i] != confirmPassword[i]) 
                return false;
        }
        
        return true;
    }
}
