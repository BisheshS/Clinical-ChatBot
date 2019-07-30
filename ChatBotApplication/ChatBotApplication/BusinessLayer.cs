using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;
namespace ChatBotApplication
{
    public class BusinessLayer
    {
        protected string provider;
        protected string connectionString;
        protected DbProviderFactory factory;
        protected DbConnection connection;
        protected Dictionary<string, string> param_ques = new Dictionary<string, string>();
        protected Dictionary<string, string> parametersDic = new Dictionary<string, string>();
        public void SetDB()
        {
            provider = ConfigurationManager.AppSettings["provider"];
            connectionString = ConfigurationManager.AppSettings["connectionString"];
            // DbProviderFactories generates an instance of a DbProviderFactory
            factory = DbProviderFactories.GetFactory(provider);
            // The DBConnection represents the DB connection
            connection = factory.CreateConnection();
            // Check if a connection was made
            if (connection == null)
            {
                Console.WriteLine("Connection Error");
                Console.ReadLine();
                //return null;
            }
            // The DB data needed to open the correct DB
            connection.ConnectionString = connectionString;
            // Open the DB connection
            connection.Open();
           // Console.WriteLine("ahgfhafhss");
        }

        //The Class which is responisble for the querying the product
        //public void GetQuestions(DbConnection connection, ref Dictionary<string, string> param_ques, DbProviderFactory factory)

        public Dictionary<string,string> GetQuestions()
        {
           
            //Allows you to pass queries to the DB
            DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return null;
                }
                // Set the DB connection for commands
                command.Connection = connection;
                try
                {
                    command.CommandText = "Select * From Question";
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to read the table");
                }
                // DbDataReader reads the row results
                // from the query
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Advance to the next results
                    while (dataReader.Read())
                    {
                        // Output results using row names
                        param_ques.Add(dataReader["Parameter"].ToString(), dataReader["Question"].ToString());
                    }
                }
                return param_ques;
                // Console.ReadLine();
            }
         public Dictionary<string,string> QueryExecute(Dictionary<string,string> param_questions)
         {
               
                // Allows you to pass queries to the Db
                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return null;
                }
                // Set the DB connection for commands
                command.Connection = connection;
                // connectionFunction(command);
                // The query you want to issue
                try
                {
                    command.CommandText = "Select * From ChatBotTableData WHERE Modular='" + param_questions["Modular"] + "' and DisplaySize='" + param_questions["DisplaySize"] + "' and Touch='" + param_questions["Touch"] + "' and Foetal='" + param_questions["Foetal"] + "'";
                }
                catch (Exception)
                {
                Console.WriteLine("Unable to access the table please check the database connection");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                }
                Dictionary<string, string> results = new Dictionary<string, string>();
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Advance to the next results
                    if (!dataReader.Read())
                    {
                    //No products exists
                    return null;
                    }
                    else
                    {
                        while (dataReader.Read())
                        {
                            //Save results using row names
                            results.Add(dataReader["ProductName"].ToString(), dataReader["Series"].ToString());
                            // Output results using row names
                        }
                    }
                connection.Close();
                }
            return results;
                //closing the connection
            }
        }
    
}
