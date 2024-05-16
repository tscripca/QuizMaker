using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

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

            using (FileStream file = File.Create(Constants.SAVED_PATH))
            {
                serializer.Serialize(file, QnACardsList);
            }
            return QnACardsList;
        }

        public static List<QuizzGame> ImportFromDrive(List<QuizzGame> loadedQnACardsList)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<QuizzGame>));

            using (FileStream loadedFile = File.OpenRead(Constants.SAVED_PATH))
            {
                deserializer.Deserialize(loadedFile);
            }
            return loadedQnACardsList;
        }
             
    }
}
