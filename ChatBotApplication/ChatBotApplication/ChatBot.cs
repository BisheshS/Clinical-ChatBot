using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;

namespace ChatBotApplication
{
    class ChatBot
    {
        static void Main(string[] args)
        {
            //Create instance of class UILayer
            UILayer uILayer = new UILayer();
            //Gets the user Details
            uILayer.Introduction();
            //Instance of Business class
            BusinessLayer process = new BusinessLayer();
            // setting up of Db connection
            process.SetDB();
            //get questions through query
            Dictionary<string, string> question_param = new Dictionary<string, string>();
            question_param = process.GetQuestions();
            //Dictionary for the parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters= uILayer.OptionsRetrieval(question_param);
            //Extract answers from the DB 
            Dictionary<string, string> results = new Dictionary<string, string>();
            //Extraction of result from Table through QueryExecute
            results= process.QueryExecute(parameters);
            //calls Displays function to display the results
            uILayer.DisplayResults(results);
            Console.ReadLine();
        }
    }
}
