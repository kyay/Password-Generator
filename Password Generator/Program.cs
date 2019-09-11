using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    class Program
    {
        private static Random rndRandomGenerator = new Random();

        //An enum of the required character types
        private enum CharType
        {
            //Signifies a number from 1 to 9 inclusive
            Number,
            //Signifies a letter from a-z inclusive
            Lowercase,
            //Signifies a letter from A-Z inclusive
            Uppercase,
            //Signifies a letter from the SPECIAL_CHARS string
            Special
        }

        //The required length of the password
        private const int PASSWORD_LENGTH = 6;

        //All the special characters allowed in the password
        private const string SPECIAL_CHARS = "!@#$%";

        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                string strPassword = "";
                //Generate all 4 types
                strPassword += GenerateRandomCharByType(CharType.Number);
                strPassword += GenerateRandomCharByType(CharType.Lowercase);
                strPassword += GenerateRandomCharByType(CharType.Uppercase);
                strPassword += GenerateRandomCharByType(CharType.Special);

                //Generate 2 more random letters
                for (int j = 0; j < PASSWORD_LENGTH - 4; j++)
                {
                    strPassword += GenerateRandomCharByType((CharType)rndRandomGenerator.Next(0, 4));
                }

                // Randomize the order of all the alphanumeric characters in the password
                strPassword = string.Join("", strPassword.OrderBy(x => rndRandomGenerator.Next(strPassword.Length)));
                //Show the password to the user
                Console.WriteLine("Your pasword is: " + strPassword);
            }
            Console.ReadKey();
        }

        //This function takes in the type of the character taht you want and returns a random character from that pool of characters
        private static char GenerateRandomCharByType(CharType type)
        {
            switch (type)
            {
                case CharType.Number:
                    return rndRandomGenerator.Next(1, 10).ToString()[0];
                case CharType.Lowercase:
                    return (char)('a' + rndRandomGenerator.Next(0, 26));
                case CharType.Uppercase:
                    return (char)('A' + rndRandomGenerator.Next(0, 26));
                case CharType.Special:
                    return SPECIAL_CHARS[rndRandomGenerator.Next(SPECIAL_CHARS.Length)];
                default:
                    //This should never happen, but just in case.
                    return ' ';
            }
        }
    }
}
