using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            int noOfAnswers = 0;
            int noOfQuestions = UIMethods.NoOfQuestions();
            UIMethods.NoOfAnswersPerQuestion(noOfAnswers);
            
            var theMainQuizz = new List<QuizzTest>();

            for (int i = 0; i < noOfQuestions; i++)
            {
                var QnACard = new QuizzTest();
                QnACard.gameQuestion = UIMethods.GetUserQuestion();
                QnACard.answersList = UIMethods.GetUserAnswers();
                theMainQuizz.Add(QnACard);
            }

           XmlSerializer serializer = new XmlSerializer(typeof(QuizzTest));

            var path = @"C:\Users\scrip\Desktop\QuizzTest.xml";

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, theMainQuizz);
            }

        }
    }
}