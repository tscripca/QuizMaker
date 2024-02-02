using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using QuizMaker;

namespace QuizMaker
{
    public class SerializerClass
    {         
        public static string StoreQnA(QnAClass randomQuestions)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QnAClass));
            var path = @"C:\Users\scrip\Desktop\myQuestions.xml";

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, randomQuestions);
                Console.WriteLine();
            }
            return serializer.ToString();
        }
    }
}
