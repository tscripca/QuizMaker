using QuizMaker;
using System.Xml.Serialization;
namespace QuizMaker
{
    public class QuizzTest
    {
        //the question on each QnACard.
        public string gameQuestion;
        //the list of answers on each QnACard.
        public List<string> answersList = new List<string>();
        public int correctAnswer;
        public override string ToString()
        {
            return $"The list contains: {answersList}";
        }
    }
}
