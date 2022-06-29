using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace RandomPasswordGenerators
{
    public static class RngCspGenerator
    {
        public static string GeneratePassword(PasswordGeneratorSettings settings)
        {
            string password = GetUniqueKey(settings.PasswordLength, settings);
            return string.Join(null, password);
        }

        public static string GetUniqueKey(int size, PasswordGeneratorSettings settings)
        {
            string chars = settings.CharacterSet;
            byte[] data = new byte[size];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();
        }

        public static bool PasswordIsValid(PasswordGeneratorSettings settings, string password)
        {
            const string REGEX_LOWERCASE = @"[a-z]";
            const string REGEX_UPPERCASE = @"[A-Z]";
            const string REGEX_NUMBER = @"[\d]";
            const string REGEX_SPECIAL = @"([!#$%&*@\\])+";

            bool lowerCaseIsValid = !settings.IncludeLowercase || (settings.IncludeLowercase && Regex.IsMatch(password, REGEX_LOWERCASE));
            bool upperCaseIsValid = !settings.IncludeUppercase || (settings.IncludeUppercase && Regex.IsMatch(password, REGEX_UPPERCASE));
            bool numberIsValid = !settings.IncludeNumber || (settings.IncludeNumber && Regex.IsMatch(password, REGEX_NUMBER));
            bool specialAreValid = !settings.IncludeSpecial || (settings.IncludeSpecial && Regex.IsMatch(password, REGEX_SPECIAL));

            return lowerCaseIsValid && upperCaseIsValid && numberIsValid && specialAreValid;
        }
    }
}