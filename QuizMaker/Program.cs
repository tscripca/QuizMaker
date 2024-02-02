using System;
using System.Xml;
using System.Xml.Serialization;
using QuizMaker;

namespace QuizMaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            QnA myQuestions = new QnA();

            Console.WriteLine("Type question: ");
            myQuestions.userQuestion = Console.ReadLine();
            Console.WriteLine("Give answer: ");
            myQuestions.userAnswer = Console.ReadLine();      
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<QnA>));

            var path = @"C:\Users\scrip\Desktop\.xml";
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, myQuestions);
                Console.WriteLine();
            }
        }         
    }  
    
    public class QnA
    {
        public string userQuestion { get; set; }
        public string userAnswer { get; set; }       
    }
}