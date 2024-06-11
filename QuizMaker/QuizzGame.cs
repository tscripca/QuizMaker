using QuizMaker;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
namespace QuizMaker
{
    public class QuizzGame
    {
        public string gameQuestion;
        public List<string> answersList = new List<string>();
        public List<string> answersToDisplay = new List<string>();
        public int correctAnswer;
    }
}
