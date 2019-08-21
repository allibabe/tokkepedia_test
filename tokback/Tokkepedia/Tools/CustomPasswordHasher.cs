using Microsoft.AspNetCore.Identity;
using Tokkepedia.Models;

namespace Tokkepedia.Tools
{
    public class CustomPasswordHasher : IPasswordHasher<TokketUser>
    {
        public string HashPassword(TokketUser user, string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(TokketUser user, string hashedPassword, string providedPassword)
        {
            return hashedPassword.Equals(providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}
