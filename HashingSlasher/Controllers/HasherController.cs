using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using HashingSlasher.Helpers;
using HashingSlasher.Models;

namespace HashingSlasher.Controllers
{
    public class HasherController : ApiController
    {
        [HttpPost]
        public string Post(HashOptions options)
        {
            var task = Task<string>.Factory.StartNew(() => GenerateHash(options));
            task.Wait();

            var hash = task.Result;
            return hash;
        }

        private string GenerateHash(HashOptions options)
        {
            switch (options.Hash)
            {
                case "MD5":
                    using (var md5 = MD5.Create())
                    {
                        return MD5Hasher.GetMd5Hash(md5, options.Text);
                    }
                case "SHA1":
                    using (var sha = SHA1.Create())
                    {
                        return SHA1Hasher.GetSha1Hash(sha, options.Text);
                    }
                case "SHA256":
                    using (var sha = SHA256.Create())
                    {
                        return SHA256Hasher.GetSha1Hash(sha, options.Text);
                    }
                default:
                    throw new InvalidOperationException("Invalid Hash Method Selected");
            }
        }
    }
}
