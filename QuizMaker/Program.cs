using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuizzCard newCard1 = new QuizzCard();
            List<QuizzCard> newList = new List<QuizzCard>();
            
            newCard1 = LogicMethods.LoopQnA();
            newList.Add(newCard1);
        }
    }
}
