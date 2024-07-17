using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Tom = new UIMethods();
            var Fred = new UIMethods();

            Tom.TomSpeakMethod();
            Fred.FredSpeakMethod();
        }
    }
}