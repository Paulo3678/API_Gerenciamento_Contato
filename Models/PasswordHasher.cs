using BCryptNet = BCrypt.Net.BCrypt;
using System.Security.Cryptography;
using System.Text;

namespace GerenciamentoContatos.Models
{
    public class PasswordHasher
    {

        public static string Encode(string password)
        {
            string passwordHash = BCryptNet.HashPassword(password);
            return passwordHash;
        }

        public static bool Verify(string password, string passwordHash)
        {
            bool isValid = BCryptNet.Verify(password, passwordHash);

            if (!isValid) { return false; }

            return true;
        }
    }
}
