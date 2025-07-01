using System.Security.Cryptography;
using System.Text;

namespace JobTracking.Application.Implementation
{
    /// <summary>
    /// Provides functionality to hash passwords using SHA256 algorithm.
    /// </summary>
    public class PasswordHasher
    {
        /// <summary>
        /// Hashes the specified password using SHA256 and returns the hexadecimal string representation.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <returns>SHA256 hashed password as a hex string.</returns>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                
                StringBuilder builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}