using System;
using System.Linq;

namespace ConsoleApp1
{
    public class MyApp
    {
        private readonly char[] ambiguous = { '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '"', '~', ',', ';', '.', '<', '>' };

        private readonly char[] similar = { 'l', '1', 'I', 'o', '0', 'O' };

        public bool CheckPassword(string password, int minSmallLetters, int minBigLetters, int minDigits, int minSymbols, bool canHaveSimilar, bool canHaveAmbiguous)
        {
            bool lettersCondition = (minSmallLetters < 0) && (minBigLetters < 0);
            bool nonLettersCondition = (minSymbols < 0) && (minDigits < 0);
            if (lettersCondition || nonLettersCondition || password == null)
            {
                return false;
            }

            bool minConditions = MinConditions(password, minSmallLetters, minBigLetters, minDigits, minSymbols);
            bool booleanConditions = HasSimilar(password, canHaveSimilar) && HasAmbiguous(password, canHaveAmbiguous);
            return minConditions && booleanConditions;
        }

        static void Main()
        {
            string pass = Console.ReadLine();
            if (!int.TryParse(Console.ReadLine(), out int minSmallLetters) || !int.TryParse(Console.ReadLine(), out int minBigLetters) || !int.TryParse(Console.ReadLine(), out int minDigits))
            {
                throw new ArgumentException("Please Provide a Number");
            }

            if (!int.TryParse(Console.ReadLine(), out int minSymbols) || !bool.TryParse(Console.ReadLine(), out bool canHaveSimilar) || !bool.TryParse(Console.ReadLine(), out bool canHaveAmbiguous))
            {
                throw new ArgumentException("Please Provide a Boolean Value");
            }

            MyApp app = new MyApp();
            Console.WriteLine(app.CheckPassword(pass, minSmallLetters, minBigLetters, minDigits, minSymbols, canHaveSimilar, canHaveAmbiguous));
        }

        private bool MinConditions(string password, int minSmallLetters, int minBigLetters, int minDigits, int minSymbols)
        {
            const int minLowerCase = 97;
            const int maxLowerCase = 122;
            const int minUpperCase = 65;
            const int maxUpperCase = 90;
            const int minDigit = 48;
            const int maxDigit = 57;
            bool minSmallLettersCondition = HasMinInRange(password, minSmallLetters, minLowerCase, maxLowerCase);
            bool minBigLettersCondition = HasMinInRange(password, minBigLetters, minUpperCase, maxUpperCase);
            bool minDigitsCondition = HasMinInRange(password, minDigits, minDigit, maxDigit);
            bool minSymbolCondition = HasMinSymbols(password, minSymbols);
            return minSmallLettersCondition && minBigLettersCondition && minDigitsCondition && minSymbolCondition;
        }

        private bool HasAmbiguous(string pass, bool canHaveAmbiguous)
        {
            bool hasAmbiguous = false;
            for (int i = 0; i < pass.Length; i++)
            {
                if (ambiguous.Contains<char>(pass[i]))
                {
                    hasAmbiguous = true;
                }
            }

            if (canHaveAmbiguous)
            {
                return true;
            }

            return !hasAmbiguous;
        }

        private bool HasSimilar(string pass, bool canHaveSimilar)
        {
            bool hasSimilar = false;
            for (int i = 0; i < pass.Length; i++)
            {
                if (similar.Contains<char>(pass[i]))
                {
                    hasSimilar = true;
                }
            }

            if (canHaveSimilar)
            {
                return true;
            }

            return !hasSimilar;
        }

        private bool HasMinInRange(string pass, int minInRange, int min, int max)
        {
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= min && pass[i] <= max)
                {
                    count++;
                }
            }

            return count >= minInRange;
        }

        private bool HasMinSymbols(string pass, int minSymbols)
        {
            const int minLowerCase = 97;
            const int maxLowerCase = 122;
            const int minUpperCase = 65;
            const int maxUpperCase = 90;
            const int minDigit = 48;
            const int maxDigit = 57;
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                bool isNotLowerCase = pass[i] < minLowerCase || pass[i] > maxLowerCase;
                bool isNotUpperCase = pass[i] < minUpperCase || pass[i] > maxUpperCase;
                bool isNotDigit = pass[i] < minDigit || pass[i] > maxDigit;
                if (isNotDigit && isNotLowerCase && isNotUpperCase)
                {
                    count++;
                }
            }

            return count >= minSymbols;
        }
    }
}
