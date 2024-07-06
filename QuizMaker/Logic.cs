using System;
using System.IO;
using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace QuizMaker
{
    public class Logic
    {
        public XmlSerializer serializer = new XmlSerializer(typeof(List<QuizzGame>));

        /// <summary>
        /// Exports the object and saves it as an XML file.
        /// </summary>
        /// <param name="CardDeckToExport"></param>
        public static void ExportToDrive(List<QuizzGame> CardDeckToExport)
        {
            using (FileStream file = File.Create(Const.SAVED_PATH))
            {
                var writeOnDisk = new XmlSerializer(typeof(List<QuizzGame>));
                writeOnDisk.Serialize(file, CardDeckToExport);
            }
        }
        /// <summary>
        /// Loads the XML file into an object list. 
        /// </summary>
        /// <returns>The object list</returns>
        public static List<QuizzGame> ImportFromDrive()
        {
            var randomPickedCard = new QuizzGame();
            var deckWithShuffledCards = new List<QuizzGame>();
            try
            {
                using (FileStream loadedFile = File.OpenRead(Const.SAVED_PATH))
                {
                    var readFromDisk = new XmlSerializer(typeof(List<QuizzGame>));
                    var importedCardDeck = readFromDisk.Deserialize(loadedFile) as List<QuizzGame>;
                    ShuffleCards(randomPickedCard, importedCardDeck, deckWithShuffledCards);
                }
            }
            catch (Exception fileDoesNotExist)
            {

            }
            return deckWithShuffledCards;
        }
        /// <summary>
        /// Shuffles the contents of a List<T>.
        /// </summary>
        /// <param name="randomCard"></param>
        /// <param name="importedDeck"></param>
        /// <param name="deckOfMixedCards"></param>
        public static void ShuffleCards(QuizzGame randomCard, List<QuizzGame> importedDeck, List<QuizzGame> deckOfMixedCards)
        {
            Random rng = new Random();
            bool allCardsAreInTheDeck = false;
            while (!allCardsAreInTheDeck)
            {
                for (int gameCardCounter = 0; gameCardCounter < importedDeck.Count; gameCardCounter++)
                {
                    foreach (QuizzGame shuffledCard in importedDeck)
                    {
                        int myIndex = rng.Next(importedDeck.Count);
                        randomCard = importedDeck[myIndex];
                        if (!deckOfMixedCards.Contains(randomCard))
                        {
                            deckOfMixedCards.Add(randomCard);
                        }
                    }
                    if (importedDeck.Count == deckOfMixedCards.Count)
                    {
                        allCardsAreInTheDeck = true;
                        break;
                    }
                }
            }
        }
    }
}