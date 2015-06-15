using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashingSlasher.Models
{
    public class PasswordOptions
    {
        public int PasswordCount { get; set; }
        public int Length { get; set; }
        public bool IsNumeric { get; set; }
        public bool IsMixedCase { get; set; }
        public bool IsPunctuated { get; set; }
        public bool HasSimilarChars { get; set; }
        
    }
}
