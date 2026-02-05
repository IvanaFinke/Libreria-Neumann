using Microsoft.AspNetCore.Identity;

namespace LibreriaNeumann.Services
{
    /*Servicio que hashea y verifica que la contaseña sea correcta*/
    public class PasswordHash
    {
        PasswordHasher<string> hasher = new PasswordHasher<string>();

        public string Hash(string password)
        {
            return hasher.HashPassword(null, password);
        }

        public bool Verify(string hash,string password)
        {
            return hasher.VerifyHashedPassword(null,hash,password) 
                == PasswordVerificationResult.Success;
        }
    }
}
