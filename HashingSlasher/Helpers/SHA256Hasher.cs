using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashingSlasher.Helpers
{
    public class SHA256Hasher
    {
        public static string GetSha1Hash(SHA256 sha, string input)
        {
            var stringBytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(stringBytes);
            return Convert.ToBase64String(hash);
        }
    }
}
