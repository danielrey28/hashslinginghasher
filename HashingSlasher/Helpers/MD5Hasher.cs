using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashingSlasher.Helpers
{
    public class MD5Hasher
    {
        public static string GetMd5Hash(MD5 hash, string input)
        {
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            
            StringBuilder sBuilder = new StringBuilder();
            
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string GetMd5Hash(MD5 md5, FileStream f)
        {
            var hash = md5.ComputeHash(f);
            return Convert.ToBase64String(hash);
        }
    }
}
