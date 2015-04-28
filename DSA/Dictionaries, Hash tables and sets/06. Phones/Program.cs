using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
using System.IO;

namespace Phones
{
    class Program
    {
        static void Main()
        {
            MultiDictionary<string, string> contactsName = new MultiDictionary<string, string>(true);
            MultiDictionary<string, string> contactsTown = new MultiDictionary<string, string>(true);

            ReadContactsFromFile("@../../phones.txt", contactsName, contactsTown);

            string[] commands = ReadCommandsFromFile("@../../commands.txt");

            ExecuteCommands(commands, contactsName, contactsTown);
        }

        private static void ExecuteCommands(string[] commands, MultiDictionary<string, string> contactsName, MultiDictionary<string, string> contactsTown)
        {
            foreach(var command in commands)
            {
                string[] commandParameters = command.Split(',');
                
                if(commandParameters.Length > 1)
                {
                    SearchByNameAndTown(commandParameters, contactsName, contactsTown);
                }
                else
                {
                    SearchByName(commandParameters, contactsName);
                }
            }
        }

        private static void SearchByName(string[] commandParameters, MultiDictionary<string, string> contactsName)
        {
            string name = commandParameters[0];
            
            var phones = contactsName[name];

            foreach (var phone in phones)
            {
                Console.WriteLine(name+" "+phone);
            }
        }

        private static void SearchByNameAndTown(string[] command, MultiDictionary<string, string> contactsName, MultiDictionary<string, string> contactsTown)
        {
            string name = command[0].Trim();
            string town = command[1].Trim();

            var phonesByName = contactsName[name];
            var phonesByTown = contactsTown[town];

            foreach(var phone in phonesByName)
            {
                foreach (var phoneNumber in phonesByTown)
                {
                    if(phone.Equals(phoneNumber))
                    {
                        Console.WriteLine(name+" "+town+" "+phone);
                    }
                }
            }
        }

        private static string[] ReadCommandsFromFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            string line = reader.ReadLine();
            List<string> commands = new List<string>();

            using (reader)
            {
                while (line != null)
                {
                    int startPosition = line.IndexOf('(');
                    int endPosition = line.LastIndexOf(')');
                    string commandParametersString = line.Substring(startPosition+1, endPosition - startPosition-1);
                    commands.Add(commandParametersString);

                    line = reader.ReadLine();
                }
            }

            return commands.ToArray();
        }

        private static void ReadContactsFromFile(string file, MultiDictionary<string, string> contactsName, MultiDictionary<string, string> contactsTown)
        {
            StreamReader reader = new StreamReader(file);
            string line = reader.ReadLine();
            
            using (reader)
            {
                while (line != null)
                {
                    var details = line.Split('|');
                    string names = details[0].Trim();
                    string town = details[1].Trim();
                    string phone = details[2].Trim();

                    contactsTown.Add(town, phone);

                    var namesSeparated = names.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var name in namesSeparated)
                    {
                        contactsName.Add(name, phone);
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
