using QuizMaker;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace QuizMaker
{
    public class QuizzGame
    {
        public string gameQuestion;
        public List<string> answersList = new List<string>();
        public int correctAnswer;
    }
}
