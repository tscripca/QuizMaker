using System.IO.Pipes;

namespace ConsoleApp2
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Type number: ");
            bool v = false;
            int newVar = 0;
            while(!v)
            {
                string userInput = Console.ReadLine();
                v = int.TryParse(userInput, out newVar);
                if (!v)
                    Console.WriteLine("Try again!");
            } 
            Console.WriteLine($"Your number is: {newVar}");
        }
    }
}