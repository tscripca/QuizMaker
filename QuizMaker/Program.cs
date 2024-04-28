using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnACard myCard1 = new();

            for (int userQuestion = 0; userQuestion <= 2; userQuestion++)
            {
                myCard1 = new QnACard();
                myCard1.gameQuestion = UIMethods.GetUserQuestion();
                myCard1.answersList = Logic.GetUserAnswers();                
            }

            XmlSerializer writer = new XmlSerializer(typeof(List<QnACard>));

            var path = @"C:\Users\scrip\Desktop\QnaCard.xml";

            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, myCard1.answersList);
            }
        }        
    }
}