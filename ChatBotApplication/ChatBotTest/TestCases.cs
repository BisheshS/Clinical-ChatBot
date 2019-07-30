using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ChatBotApplication;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System;

namespace ChatBotTest
{
    [TestFixture]
    class Test
    {
        [SetUp]
        public void Setup()
        {
            ConfigurationManager.AppSettings["provider"] = "System.Data.SqlClient";
            ConfigurationManager.AppSettings["connectionString"] = "Data Source=INGBTCPIC5NBZZP;Initial Catalog=ChatBotDB;Integrated Security=True;Pooling=False";
        }

        [Test]
        public void TestingFoetalQuestion()
        {
            BusinessLayer businessLayer = new BusinessLayer();
            Dictionary<string, string> questions = new Dictionary<string, string>();
            businessLayer.SetDB();
            questions = businessLayer.GetQuestions();
            string str = "What kind of monitor you'd like? ";
            Assert.AreEqual(questions["Foetal-Foetal-NonFoetal"].ToString(),str);
            //Assert.AreEqual("Foetal")
        }
        [Test]
        public void TestingModularQuestion()
        {
            BusinessLayer businessLayer = new BusinessLayer();
            Dictionary<string, string> questions = new Dictionary<string, string>();
            businessLayer.SetDB();
            questions = businessLayer.GetQuestions();
            string str = "Do you need modularity in your monitor? Choose the kind you'd like?";
            Assert.AreEqual(questions["Modular-Modular-NonModular"].ToString(), str);
        }

        [Test]
        public void TestingTouchQuestion()
        {
            BusinessLayer businessLayer = new BusinessLayer();
            Dictionary<string, string> questions = new Dictionary<string, string>();
            businessLayer.SetDB();
            questions = businessLayer.GetQuestions();
            string str = "Do you need touch screen in your monitor? Choose the kind you'd like? ";
            Assert.AreEqual(questions["Touch-TouchEnabled-TouchDisabled"].ToString(), str);
        }

        [Test]
        public void TestingPortabilityQuestion()
        {
            BusinessLayer businessLayer = new BusinessLayer();
            Dictionary<string, string> questions = new Dictionary<string, string>();
            businessLayer.SetDB();
            questions = businessLayer.GetQuestions();
            string str = "Do you need portability in your monitor? Choose the kind you'd like?";
            Assert.AreEqual(questions["Portability-Portable-NotPortable"].ToString(), str);
        }

        [Test]
        public void TestingDisplaySizeQuestion()
        {
            BusinessLayer businessLayer = new BusinessLayer();
            Dictionary<string, string> questions = new Dictionary<string, string>();
            businessLayer.SetDB();
            questions = businessLayer.GetQuestions();
            string str = "What is the display size you need in your monitor? Choose the kind you'd like?";
            Assert.AreEqual(questions["DisplaySize-Small-Medium-Large"].ToString(), str);
        }

        [Test]
        public void RetrieveFoetalOptions()
        {
            UILayer uILayer = new UILayer();
            Dictionary<string, string> parameters_ques = new Dictionary<string, string>();
            Dictionary<string,string> parameters = new Dictionary<string, string>();
            parameters_ques.Add("Foetal-Foetal-NonFoetal", "What kind of monitor you'd like? ");
            parameters=uILayer.OptionsRetrieval(parameters);
            parameters.Add("Foetal", "Foetal");
            Assert.AreEqual(parameters["Foetal"].ToString(), "Foetal");
        }

        [Test]
        public void RetrieveNonFoetalOptions()
        {
            UILayer uILayer = new UILayer();
            Dictionary<string, string> parameters_ques = new Dictionary<string, string>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters_ques.Add("Foetal-Foetal-NonFoetal", "What kind of monitor you'd like? ");
            parameters = uILayer.OptionsRetrieval(parameters);
            parameters.Add("Foetal", "NonFoetal");
            Assert.AreEqual(parameters["Foetal"].ToString(), "NonFoetal");
        }

        [Test]
        public void QueryExecuteEfficiaValue()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Foetal", "Foetal");
            parameters.Add("Modular", "NonModular");
            parameters.Add("Touch", "TouchDisabled");
            parameters.Add("Portability", "NotPortable");
            parameters.Add("DisplaySize", "Large");
            BusinessLayer businessLayer = new BusinessLayer();
            businessLayer.SetDB();
            Dictionary<string, string> results = new Dictionary<string, string>();
            results = businessLayer.QueryExecute(parameters);
            foreach (KeyValuePair<string, string> displayProduct in results)
            {
                Assert.AreNotEqual(displayProduct.Value.ToString(), "Efficia");
            }
            
        }

        [Test]
        public void QueryExecuteAvalonKey()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Foetal", "Foetal");
            parameters.Add("Modular", "Modular");
            parameters.Add("Touch", "TouchEnabled");
            parameters.Add("Portability", "NotPortable");
            parameters.Add("DisplaySize", "Small");
            BusinessLayer businessLayer = new BusinessLayer();
            businessLayer.SetDB();
            Dictionary<string, string> results = new Dictionary<string, string>();
            results = businessLayer.QueryExecute(parameters);
            
            foreach (KeyValuePair<string, string> displayProduct in results)
            {
                //System.Console.WriteLine("Key = {0}, Value = {1}", displayProduct.Key, displayProduct.Value);
                Assert.AreNotEqual(displayProduct.Key.ToString(), "AvalonCL");
              //  Assert.AreEqual(displayProduct.Key[1].ToString(), "EfficiaCMS200");
            }
        }

        [Test]
        public void QueryExecuteAvalonValue()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Foetal", "Foetal");
            parameters.Add("Modular", "Modular");
            parameters.Add("Touch", "TouchEnabled");
            parameters.Add("Portability", "NotPortable");
            parameters.Add("DisplaySize", "Small");
            BusinessLayer businessLayer = new BusinessLayer();
            businessLayer.SetDB();
            Dictionary<string, string> results = new Dictionary<string, string>();
            results = businessLayer.QueryExecute(parameters);
          
            foreach (KeyValuePair<string, string> displayProduct in results)
            {
                Assert.AreEqual(displayProduct.Value.ToString(), "Avalon");
            }
        }

    }
}