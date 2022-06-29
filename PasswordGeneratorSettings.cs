using System.Text;

namespace RandomPasswordGenerators
{
    public class PasswordGeneratorSettings
    {
        const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBER_CHARACTERS = "0123456789";
        const string SPECIAL_CHARACTERS = @"!#$%&*@\";

        public bool IncludeLowercase { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeNumber { get; set; }
        public bool IncludeSpecial { get; set; }
        public int PasswordLength { get; set; }
        public string CharacterSet { get; set; }

        public PasswordGeneratorSettings(bool includeLowercase, bool includeUppercase, bool includeNumber, bool includeSpecial, int passwordLength)
        {
            IncludeLowercase = includeLowercase;
            IncludeUppercase = includeUppercase;
            IncludeNumber = includeNumber;
            IncludeSpecial = includeSpecial;
            PasswordLength = passwordLength;

            StringBuilder characterSet = new StringBuilder();

            if (includeLowercase)
            {
                characterSet.Append(LOWERCASE_CHARACTERS);
            }

            if (includeUppercase)
            {
                characterSet.Append(UPPERCASE_CHARACTERS);
            }

            if (includeNumber)
            {
                characterSet.Append(NUMBER_CHARACTERS);
            }

            if (includeSpecial)
            {
                characterSet.Append(SPECIAL_CHARACTERS);
            }

            CharacterSet = characterSet.ToString();
        }
    }
}