using QuizMaker;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

public class Data
{

    /// <summary>
    /// Trying to Read the text file.
    /// </summary>
    /// <param name="filepath">selected file path</param>
    /// <returns>
    /// if succeeded returning an array if not returning null
    /// </returns>
    public static string[] GetQuestionsFromTextFile(string filepath)
    {
        string[] textlines = null;

        try
        {
            textlines = File.ReadAllLines(filepath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error by getting the questions from text file: {e.Message}");
        }
       
        return textlines;
    }

    /// <summary>
    /// Reading the Question from array and adding questions and answers into List of QnA objects
    /// </summary>
    /// <param name="textlines">selected array</param>
    /// <returns>List of QnA objects
    /// Question stored Question
    /// Answers - wrong answers
    /// CorrectAnswers - correct answers
    /// </returns>
    public static List<QnA> GetQuestionsFromArray(string[] textlines)
    {
        List<QnA> questions = new();
        int count = 0;

        foreach (var line in textlines)
        {
            count++;

            QnA question = new();
            var lineArray = line.Split("?");

            if (lineArray.Length > 0)
            {
                question.Question = lineArray[0].Trim() + "?";
                var answers = lineArray[1].Split("|");

                for (int i = 0; i < answers.Length; i++)
                {
                    if (answers[i].Trim() != string.Empty)
                    {
                        if (answers[i].Contains("*"))
                        {
                            question.CorrectAnswer = i - 1;
                        }

                        question.Answers.Add(answers[i].Trim().Replace("*", ""));

                    }
                }

                if (question.CorrectAnswer != null)
                {
                    questions.Add(question);
                }

            }
        }

        return questions;
    }
   
    /// <summary>
    /// Getting questions from file and loading to QnA list object
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>
    /// Loaded QnA list object if succeeded to read from file, if not return null
    /// </returns>
    public static List<QnA> LoadQuestionList(string filePath)
    {
        List<QnA> list = null;

        string[] textlines = GetQuestionsFromTextFile(filePath);

        if (textlines != null)
        {
            list = GetQuestionsFromArray(textlines);
        }

        return list;
    }

    /// <summary>
    /// Serialize T object in to file set in parameter file under "xspath"
    /// </summary>
    /// <typeparam name="T"> Generic object </typeparam>
    /// <param name="someObject"></param>
    public static void Serialize<T>(T someObject)
    {
        XmlSerializer xs = new(typeof(T));
        FileStream fsout = new(ConfigurationManager.AppSettings.Get("xspath"), FileMode.Create, FileAccess.Write, FileShare.None);

        try
        {
            using (fsout)
            {
                xs.Serialize(fsout, someObject);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error by storing the questions: {e.Message}");
        }
    }

    /// <summary>
    /// De-serialize object
    /// </summary>
    /// <typeparam name="T"> object Type </typeparam>
    /// <returns> De-serialized object</returns>
    public static T Desirialize<T>() where T: new()
    {

        XmlSerializer xs = new(typeof(T));
        FileStream fsout = new(ConfigurationManager.AppSettings.Get("xspath"), FileMode.Open, FileAccess.Read, FileShare.None);
        T obj = new();

        try
        {
            using (fsout)
            {
                obj = (T)xs.Deserialize(fsout);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error by retrieving an object: {e.Message}");
        }

        return obj;
    }
}
