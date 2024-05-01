using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mainQuizzList = UIMethods.LoopTheQnACards();
            Logic.ExportToDrive(mainQuizzList);
        }
    }
}