using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using HashingSlasher.Helpers;
using HashingSlasher.Models;

namespace HashingSlasher.Controllers
{
    public class PasswordController : ApiController
    {
        [HttpPost]
        public List<string> Post(PasswordOptions options)
        {
            if (options == null)
            {
                options = new PasswordOptions
                {
                    HasSimilarChars = true,
                    IsMixedCase = true,
                    IsPunctuated = true,
                    IsNumeric = true,
                    Length = 8,
                    PasswordCount = 1
                };
            }

            var task = new List<Task<string>>();
            for (int i = 0; i < options.PasswordCount; i++)
            {
                task.Add(Task<string>.Factory.StartNew(() => PasswordGenerator.GeneratePassword(options)));    
            }
            
            Task.WaitAll(task.ToArray());

            var passwords = task.Select(t => t.Result).ToList();
            return passwords;
        }
        
       
        
    }
}
