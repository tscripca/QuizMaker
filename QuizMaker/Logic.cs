using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class Logic
    {
        /// <summary>
        /// Exports a list of objects to local storage.
        /// </summary>
        /// <param name="passTheList"></param>
        /// <returns>A List of objects.</returns>
        public static List<QuizzTest> ExportToDrive(List<QuizzTest> QnACardsList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizzTest>));
            string path = @"QuizzTest.xml";

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, QnACardsList);
            }
            return QnACardsList;
        }
             
    }
}
