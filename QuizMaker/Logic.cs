using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace QuizMaker
{
    public class Logic
    {
        public XmlSerializer serializer = new XmlSerializer(typeof(List<QuizzGame>));
        /// <summary>
        /// Saves the input content on the local drive.
        /// </summary>
        /// <param name="QnACardsList"></param>
        public static void ExportToDrive(List<QuizzGame> QnACardsList)
        {
            using (FileStream file = File.Create(Constants.SAVED_PATH))
            {
                var writeDsk = new XmlSerializer(typeof(List<QuizzGame>));
                writeDsk.Serialize(file, QnACardsList);
            }
        }
        /// <summary>
        /// Loads an XML file into an objects list.
        /// </summary>
        /// <param name="loadedQnACardsList"></param>
        /// <returns></returns>
        public static List<QuizzGame> ImportFromDrive()
        {
            var importedQnAList = new List<QuizzGame>();
            using (FileStream loadedFile = File.OpenRead(Constants.SAVED_PATH))
            {
                var readDisk = new XmlSerializer(typeof(List<QuizzGame>));
                importedQnAList = readDisk.Deserialize(loadedFile) as List<QuizzGame>;
            }
            return importedQnAList;
        }
    }
}
