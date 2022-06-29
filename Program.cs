using System;
using System.Diagnostics;
using System.IO;

namespace RandomPasswordGenerators
{
    public class Program
    {
        public static void Main()
        {
            const int MAXIMUM_PASSWORD_ATTEMPTS = Int32.MaxValue;
            bool includeLowercase;
            bool includeUppercase;
            bool includeNumber;
            bool includeSpecial;
            int passwordLength;
            int temp;

        while (true)
        {
                while (true)
                {
                    Console.WriteLine("Do you want lowercase letters to be in your password?");
                    string tempIncludeLowercase = Console.ReadLine();

                    if (tempIncludeLowercase.ToUpper() == "YES")
                    {
                        includeLowercase = true;
                        break;
                    }
                    else if (tempIncludeLowercase.ToUpper() == "NO")
                    {
                        includeLowercase = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please, enter a valid answer ---> (YES or NO)\n");
                        continue;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Do you want uppercase letters to be in your password?");
                    string tempIncludeUppercase = Console.ReadLine();

                    if (tempIncludeUppercase.ToUpper() == "YES")
                    {
                        includeUppercase = true;
                        break;
                    }
                    else if (tempIncludeUppercase.ToUpper() == "NO")
                    {
                        includeUppercase = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please, enter a valid answer ---> (YES or NO)\n");
                        continue;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Do you want number to be in your password?");
                    string tempIncludeNumber = Console.ReadLine();

                    if (tempIncludeNumber.ToUpper() == "YES")
                    {
                        includeNumber = true;
                        break;
                    }
                    else if (tempIncludeNumber.ToUpper() == "NO")
                    {
                        includeNumber = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please, enter a valid answer ---> (YES or NO)\n");
                        continue;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Do you want special character to be in your password?");
                    string tempIncludeSpecial = Console.ReadLine();

                    if (tempIncludeSpecial.ToUpper() == "YES")
                    {
                        includeSpecial = true;
                        break;
                    }
                    else if (tempIncludeSpecial.ToUpper() == "NO")
                    {
                        includeSpecial = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please, enter a valid answer ---> (YES or NO)\n");
                        continue;
                    }
                }

                int temp1 = includeLowercase ? 1 : 0;
                int temp2 = includeUppercase ? 1 : 0;
                int temp3 = includeNumber ? 1 : 0;
                int temp4 = includeSpecial ? 1 : 0;
                int sum = temp1 + temp2 + temp3 + temp4;

                if(sum > 0)
                    break;
                else
                {
                    Console.WriteLine("Please, choose minimum one option for generating password!");
                    Console.WriteLine("------------------------------------------------------------");
                    continue;
                }
            }
            

            while (true)
            {
                Console.WriteLine("\nPlease, insert the desired password length:");
                string tempLengthOfPassword = Console.ReadLine();

                if (tempLengthOfPassword == "")
                {
                    Console.WriteLine("The input can not be empty!");
                    continue;
                }
                else if (!int.TryParse(tempLengthOfPassword, out temp))
                {
                    Console.WriteLine("Try again!");
                    continue;
                }
                else
                {
                    passwordLength = temp;
                    if (passwordLength >= 8 && passwordLength <= 50)
                    {
                        Console.WriteLine("The length of the password will be {0}.", passwordLength);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password length is not in the given interval [8-50]");
                        Console.WriteLine("---------------------------------------------------");
                        continue;
                    }
                }
            }

            ConsoleKeyInfo keyInformation;

            do
            {
                Console.WriteLine("\nSelect one of the algorithms to generate random passwords (ESC to exit):");
                Console.WriteLine("1.Using Random");
                Console.WriteLine("2.Using RNGCryptoServiceProvider");
                Console.WriteLine("3.Using Linear Congruental\n");

                keyInformation = Console.ReadKey();

                if (keyInformation.Key == ConsoleKey.D1)
                {
                    do
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        PasswordGeneratorSettings settings = new PasswordGeneratorSettings(includeLowercase, includeUppercase, includeNumber, includeSpecial, passwordLength);

                        string password;
                        int passwordAttempts = 0;

                        do
                        {
                            password = RandomGenerator.GeneratePassword(settings);
                            passwordAttempts++;
                        }
                        while (passwordAttempts < MAXIMUM_PASSWORD_ATTEMPTS && !RandomGenerator.PasswordIsValid(settings, password));

                        timer.Stop();
                        Console.WriteLine("\nTime: {0}", timer.Elapsed);
                        Console.WriteLine("Your password is: {0}", password);
                        Console.WriteLine("---------------------------------");

                        string textRandom = "\n" + $"{password}";
                        File.AppendAllText("RandomGeneratorStorage.txt", textRandom + '\n');

                        keyInformation = Console.ReadKey();
                    }
                    while (keyInformation.Key != ConsoleKey.F1);
                }
                else if (keyInformation.Key == ConsoleKey.D2)
                {
                    do
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        PasswordGeneratorSettings settings = new PasswordGeneratorSettings(includeLowercase, includeUppercase, includeNumber, includeSpecial, passwordLength);

                        string password;
                        int passwordAttempts = 0;

                        do
                        {
                            password = RngCspGenerator.GeneratePassword(settings);
                            passwordAttempts++;
                        }
                        while (passwordAttempts < MAXIMUM_PASSWORD_ATTEMPTS && !RngCspGenerator.PasswordIsValid(settings, password));

                        timer.Stop();
                        Console.WriteLine("\nTime: {0}", timer.Elapsed);
                        Console.WriteLine("Your password is: {0}", password);
                        Console.WriteLine("---------------------------------");

                        string textRngCsp = "\n" + $"{password}";
                        File.AppendAllText("RngCspGeneratorStorage.txt", textRngCsp + '\n');

                        keyInformation = Console.ReadKey();
                    }
                    while (keyInformation.Key != ConsoleKey.F2);
                }
                else if (keyInformation.Key == ConsoleKey.D3)
                {
                    do
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        PasswordGeneratorSettings settings = new PasswordGeneratorSettings(includeLowercase, includeUppercase, includeNumber, includeSpecial, passwordLength);

                        string password;
                        int passwordAttempts = 0;

                        do
                        {
                            password = LinearCongruentialGenerator.GeneratePassword(settings);
                            passwordAttempts++;
                        }
                        while (passwordAttempts < MAXIMUM_PASSWORD_ATTEMPTS && !LinearCongruentialGenerator.PasswordIsValid(settings, password));

                        timer.Stop();
                        Console.WriteLine("\nTime: {0}", timer.Elapsed);
                        Console.WriteLine("Your password is: {0}", password);
                        Console.WriteLine("---------------------------------");

                        string textLC = "\n" + $"{password}";
                        File.AppendAllText("LcGeneratorStorage.txt", textLC + '\n');

                        keyInformation = Console.ReadKey();
                    }
                    while (keyInformation.Key != ConsoleKey.F3);
                }
                else
                    Console.WriteLine("\nWrong option!");
            }
            while (keyInformation.Key != ConsoleKey.Escape);
        }
    }
}