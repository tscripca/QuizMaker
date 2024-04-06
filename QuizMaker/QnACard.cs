using QuizMaker;
using System.Collections.Generic;

namespace QuizMaker
{
    public class QnACard
    {
        public string gameQuestion;
        public List<QnACard> answersList = new List<QnACard> ();
        public int correctAnswer;

        public override string ToString()
        {
            return $"{gameQuestion},{answersList}";
        }
    }
}
