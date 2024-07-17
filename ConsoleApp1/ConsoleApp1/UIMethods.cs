using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UIMethods
    {
        public void TomSpeakMethod()
        {
            var TomTom = new Logic();
            string tomText = "Hi my name is Tom!";

            Console.WriteLine($"Tom's text has {TomTom.Actions(tomText)} characters!");
        }

        public void FredSpeakMethod()
        {
            var FredFred = new Logic();
            string fredText = "Hi Tom, my name is Fred!";

            Console.WriteLine($"Fred's text has {FredFred.Actions(fredText)} characters!.");
        }
    }
}
