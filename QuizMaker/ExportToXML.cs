using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using QuizMaker;
namespace QuizMaker
{
    public class ExportToXML
    {
        public static string StoreQuestions()
        {
            string typeQuestion = "";
            XmlSerializer serializer = new XmlSerializer(typeof(List<QnA>));
            string relativePath = @"myQuestionsAndAnswers.xml";
            using (FileStream file = File.Create(relativePath))
            {
                serializer.Serialize(file, typeQuestion);
                Console.WriteLine();
            }
            return QnA.GetUserQuestions();
        }
        public static string StoreAnswers()
        {
            string typeAnswers = "";
            XmlSerializer serializer = new XmlSerializer(typeof(List<QnA>));
            string relativePath = @"myQuestionsAndAnswers.xml";
            using (FileStream file = File.Create(relativePath))
            {
                serializer.Serialize(file, typeAnswers);
                Console.WriteLine();
            }
            return typeAnswers.ToString();
        }
    }
}
