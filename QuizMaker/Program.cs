using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {          
            QuizzCard QnACard = new QuizzCard();

            QnACard.QuestionsAndAnswers = LogicMethods.SetNumberOfQnA();

            Console.WriteLine($"{QnACard.QuestionsAndAnswers}"); 
        }        
    }    
}