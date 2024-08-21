namespace P6_QuizMaker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO: BONUS: Update stored the Q/A in a file and restore them.

            bool continuePlay;
            Random rnd = new Random();

            do
            {
                //Game Info
                GameInfo trivia = new GameInfo();
                UI.PrintGameHeadline(trivia.Title);
                UI.PrintGameInstructions(trivia.Description);

                //Quiz DB Creation
                List<Quiz> quizDB = UI.GetQuizCards();
                XML.ExportFile(quizDB);

                //Player Info
                UI.PrintGameHeadline(trivia.Title);
                int numOfPlayers = UI.HowManyPlayers();
                List<Player> playersDB = UI.GetPlayersInfo(numOfPlayers);

                //Topic presentation
                do
                {
                    UI.PrintGameHeadline(trivia.Title);
                    Player currentPlayer = UI.SelectOption<Player>(playersDB);

                    Quiz chosenTopic = UI.SelectOption<Quiz>(quizDB);
                    List<Quiz> questionsOfChosenTopic = quizDB.Where(item => item.Topic == chosenTopic.Topic).ToList();

                    int max = questionsOfChosenTopic.Count();

                    //Quiz presentation
                    do
                    {
                        int rndIndex = rnd.Next(0, max);
                        Quiz shuffledQuiz = questionsOfChosenTopic[rndIndex]; //Saves aside the rndQuiz to keep the original intact

                        List<string> shuffledAnswers = shuffledQuiz.Answers.OrderBy(item => rnd.Next()).ToList();//Shuffles the rndQuiz answers before presenting them to the players
                        shuffledQuiz.Answers = shuffledAnswers; //Replaces the original shuffledQuiz answers with the shuffledAnswers, so the order of the answers will always different   


                        //Players' score calc 
                        bool isRightAnswer = UI.GetPlayerQuizAnswer(shuffledQuiz);
                        if (isRightAnswer == false) //If the answer wasn't right, replace player for the next one
                        {
                            break;
                        }

                        currentPlayer.Score = currentPlayer.Score + 10;//Calculates the player's score
                        questionsOfChosenTopic.Remove(shuffledQuiz); //Deletes the quiz from my filtered list (inner while)
                        quizDB.Remove(shuffledQuiz); //Deletes the quiz from the main list (outer while)
                        max--;

                    } while (max >= 1);


                }while (quizDB.Count > 0);

                //Present the final scores
                UI.PrintGameHeadline(trivia.Title);
                UI.PrintPlayersFinalScore(playersDB);
                continuePlay = UI.WantContinueGame();

            } while (continuePlay == false);

        }
    }
}