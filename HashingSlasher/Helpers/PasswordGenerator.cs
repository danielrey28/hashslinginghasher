using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashingSlasher.Models;

namespace HashingSlasher.Helpers
{
    class PasswordGenerator
    {
        public static string GeneratePassword(PasswordOptions options)
        {
            var seed = RandomTPL.Next();
            var r = new Random(seed);

            var passwordBuilder = new StringBuilder();
            var optionsBuilder = new StringBuilder(lowerCase);

            if (options.IsMixedCase)
            {
                optionsBuilder.Append(upperCase);
            }

            if (options.IsNumeric)
            {
                optionsBuilder.Append(numericChars);
            }

            if (options.IsPunctuated)
            {
                optionsBuilder.Append(specialChars);
            }

            var passwordOptions = optionsBuilder.ToString().ToCharArray();

            for (int i = 0; i < options.Length; i++)
            {
                if (!options.HasSimilarChars)
                {
                    passwordBuilder.Append(passwordOptions[r.Next(0, passwordOptions.Length)]);
                }
                else
                {
                    while (true)
                    {
                        var tryCharacter = passwordOptions[r.Next(0, passwordOptions.Length)];
                        if (!CharInString(tryCharacter, passwordBuilder))
                        {
                            passwordBuilder.Append(passwordOptions[r.Next(0, passwordOptions.Length)]);
                            break;
                        }
                    }
                }
            }

            return passwordBuilder.ToString();

        }

        private static bool CharInString(char tryCharacter, StringBuilder passwordBuilder)
        {
            for (int i = 0; i < passwordBuilder.Length; i++)
            {
                if (tryCharacter == passwordBuilder[i])
                {
                    return true;
                }
            }
            return false;
        }

        private static string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        private static string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string specialChars = "*$-+?_&=!%{}/";
        private static string numericChars = "0123456789";
    }
}
