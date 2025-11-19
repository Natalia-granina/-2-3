using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace практическая_2.Services
{
    internal class Hash
    {
        public static string HashPassw(string password)
        {
            using (SHA256 hash256 = SHA256.Create())
            {
                byte[] bytePassw = Encoding.UTF8.GetBytes(password);
                byte[] hash = hash256.ComputeHash(bytePassw);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }
}
