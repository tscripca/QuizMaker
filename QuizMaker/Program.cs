using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {            
            //UIMethods.DeployGame();
            
            QuizzGame xmlList = new QuizzGame();

            xmlList.importedList = Logic.ImportFromDrive();

            var wtf = xmlList.importedList;
            Console.WriteLine($"Your quizz game is: {wtf.ToString()}");
        }
    }
}