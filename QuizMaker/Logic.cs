﻿using System.Xml.Serialization;

namespace QuizMaker
{
    public class Logic
    {
        private static readonly XmlSerializer serializer = new(typeof(List<QuizzGame>));
        private static readonly Random rng = new();

        /// <summary>
        /// Exports the object and saves it as an XML file.
        /// </summary>
        /// <param name="CardDeckToExport"></param>
        public static void ExportToDrive(List<QuizzGame> CardDeckToExport)
        {
            using (FileStream file = File.Create(Const.SAVED_PATH))
            {               
                serializer.Serialize(file, CardDeckToExport);
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
            using (FileStream loadedFile = File.OpenRead(Const.SAVED_PATH))
            {
                var importedCardDeck = serializer.Deserialize(loadedFile) as List<QuizzGame>;
                ShuffleCards(randomPickedCard, importedCardDeck, deckWithShuffledCards);
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