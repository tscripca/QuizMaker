namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] vendingMachine = new int[0, 25];

            Console.WriteLine("Select item: ");
            int userSelection = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= vendingMachine.Length; i++)
            {
                Console.WriteLine($"Number {userSelection} has been selected");
            }

        }
    }
}
