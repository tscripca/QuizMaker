using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using QuizMaker;

namespace QuizMaker
{
    public class QnA
    {
        public string userQuestion { get; set; }
        public string userAnswer { get; set; }

        public string getUserQuestion(string userQuestion)
        {
            Console.WriteLine("Type question: ");
            userQuestion = Console.ReadLine();
            return userQuestion;
        }
        public string getUserAnswer(string userAnswer)
        {
            Console.WriteLine("Type the answer: ");
            userAnswer = Console.ReadLine();
            return userAnswer;
        }
    }
}
