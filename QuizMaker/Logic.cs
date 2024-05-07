using QuizMaker;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class Logic
    {
        /// <summary>
        /// Exports a list of objects to local storage.
        /// </summary>
        /// <param name="QnACardsList"></param>
        /// <returns>A list of objects.</returns>
        public static List<QuizzGame> ExportToDrive(List<QuizzGame> QnACardsList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizzGame>));

            using (FileStream file = File.Create(Constants.savedPath))
            {
                serializer.Serialize(file, QnACardsList);
            }
            return QnACardsList;
        }
             
    }
}
