using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using QuizMaker;

namespace QuizMaker
{
    public class Serializer
    {
        public string storeQnA(string userInput)
        {            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QnA>));

            var path = @"C:\Users\scrip\Desktop\C# Projects\QuizMaker";

            using FileStream file = File.Create(path);
            {
                xmlSerializer.Serialize(file, userInput);
            }
            return userInput;
        }
    }
}
