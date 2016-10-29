using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_MySqlAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            string userChoice = "a";
            ConsoleCommands userConsoleCommands = new ConsoleCommands();

            while (true)
            {
                Console.WriteLine("** MySql Server Access Via C# Console Example **");
                Console.WriteLine("Enter a command:\n0. For Name List\n1. To Add A Name\n2. To Delete A Name\nX. To Exit");
                userChoice = Console.ReadLine();
                if (userChoice == "X")
                {
                    Console.WriteLine("** Exiting Program **");
                    break;

                } else
                {
                    Console.WriteLine(userConsoleCommands.CheckUserString(userChoice) + "\n");
                    Console.ReadLine();
                }
            }

            Console.Read();
        }
    }
}
