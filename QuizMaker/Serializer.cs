using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using QuizMaker;

namespace QuizMaker
{
    public class Serializer
    {      
        /// <summary>
        /// This method exports the loaded data from other methods to an XML file at a specified path
        /// </summary>
        public static void StoreMyQnA(List<string> listOfUserInput)
        {            
            XmlSerializer writer = new XmlSerializer(typeof(List<QnACard>));

            var path = @"C:\Users\scrip\Desktop\myQuestions.xml";

            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file,listOfUserInput);
            }
        }
    }
}
