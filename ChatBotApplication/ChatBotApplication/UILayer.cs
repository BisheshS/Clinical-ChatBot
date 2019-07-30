using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotApplication
{
    public class UILayer:BusinessLayer
    {
        //Printing basics
        private string bot = "BOT: ";
        private string user = "YOU: ";
        //The Data Members for the User using the Chatbot
        public string customerName;
        public string customerLocation;
        protected Dictionary<string, string> parameters = new Dictionary<string, string>();
       // protected Dictionary<string, string> question_parameter = new Dictionary<string, string>();

        public void Introduction()
        {
            Console.WriteLine(bot + "Hello, Welcome to patient monitoring chatbot!");
            Console.WriteLine(bot + "Please follow the steps to select the product you are looking for");
            Console.WriteLine(bot + "May I know your name?");
            Console.Write(user);
            customerName = Console.ReadLine();
            Console.Write(bot);
            Console.WriteLine("Hi "+customerName+" which city are you from?");
            Console.Write(user);
            customerLocation = Console.ReadLine();
        }
        public Dictionary<string,string> OptionsRetrieval(Dictionary<string,string> question_parameter)
        {
            
            //Print questions in order
            foreach (KeyValuePair<string, string> questions in question_parameter)
            {
                Console.WriteLine("Bot: " + "{0}", (questions.Value).ToString());
                string[] options = ((questions.Key).ToString()).Split('-');
                //Give options to users
                for (int i = 1; i < options.Length; i++)
                {
                    Console.WriteLine("\nBot: {0}.{1}", i, options[i]);
                }
                Console.Write("You: ");
                //Take input from the user 
                var res = Console.ReadLine();
                bool flag1 = true;
                do
                {
                    for (int i = 1; i < options.Length; i++)
                    {
                        if ((res == (i).ToString()) || (options[i].ToLower()).Equals(res.ToLower()))
                        {
                            parameters.Add(options[0], options[i]);
                            flag1 = false;
                            break;

                        }
                    }
                    if (flag1 == true)
                    {
                        Console.WriteLine("Hello " + customerName + " you have entered the wrong option!");
                        Console.WriteLine("Please choose the selected option given above");
                        res = Console.ReadLine();
                    }
                } while (flag1 == true);
            }
            return parameters;
        }
        public void DisplayResults(Dictionary<string, string> results)
        {
            try
            {
                Console.WriteLine("The Product matching your required qualities are:");
                foreach (KeyValuePair<string, string> displayProduct in results)
                {
                    Console.WriteLine("{0} from the Series {1}", displayProduct.Key, displayProduct.Value);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("No such product exists");
            }
        }

    }
}
