using System;
using System.Text.RegularExpressions;

namespace RandomPasswordGenerators
{
    public static class RandomGenerator
    {
        public static string GeneratePassword(PasswordGeneratorSettings settings)
        {
            char[] password = new char[settings.PasswordLength];
            int characterSetLength = settings.CharacterSet.Length;

            Random random = new Random();
            for (int characterPosition = 0; characterPosition < settings.PasswordLength; characterPosition++)
            {
                password[characterPosition] = settings.CharacterSet[random.Next(characterSetLength - 1)];
            }

            return string.Join(null, password);
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
