//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace ChatBotApplication
//{
//    class NUnitTestClass1
//    {
//        private string provider;

//        public void Test1()
//        { 
//            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
//            // The DBConnection represents the DB connection
//            DbConnection connection = factory.CreateConnection();
//            // var dict = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };
//            var dict = new Dictionary<string, string> { ["one"] = "Modularity", ["two"] = "Do you need modularity inyour monitor?Choose the kind you'd like?" };
//            BusinessLayer business = new BusinessLayer();
//            business.getQuestions(connection, ref dict,factory);
//            Assert.AreEqual())
//        }
//    }
//}
