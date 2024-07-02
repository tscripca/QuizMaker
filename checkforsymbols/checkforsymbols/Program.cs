namespace checkforsymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            bool containsDigits = true;
            bool containsSymbols = true;
            string stringToCheck = default;
            List<char> listOfSymbols = new List<char>
            {
                '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+',
                '[', '{', ']', '}', '#', '~', ';', ':', '@', '<', ',', '.', '>', '/',
                '\'', '|'
            };
            Console.WriteLine("Type: ");
            while (containsDigits || containsSymbols)
            {
                stringToCheck = Console.ReadLine();
                foreach (char letter in stringToCheck)
                {
                    foreach (char symbol in listOfSymbols)
                    {
                        if (letter == symbol)
                        {
                            Console.WriteLine($"Symbol {symbol} found!");
                        }
                        else containsSymbols = false;
                    }
                    if (stringToCheck.Any(char.IsDigit))
                        Console.WriteLine("Contains numbers!");
                    else containsDigits = false;
                }
            }
        }
    }
}