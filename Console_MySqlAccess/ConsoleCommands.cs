using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_MySqlAccess.MySqlCommands;

namespace Console_MySqlAccess
{
    class ConsoleCommands
    {
        DatabaseAccess userDatabaseAccess = new DatabaseAccess();

        public string CheckUserString(string sentUserString)
        {
            switch (sentUserString[0])
	        {
		        case '0':
                    List<NameObject> returnedNameList = userDatabaseAccess.GetAllNamesFromDatabase();
                    string userTable = "List of Names\n";

                    foreach (var currentRow in returnedNameList)
                    {
                        userTable += $"ID: {currentRow.NameID}, Name: {currentRow.FirstName} {currentRow.LastName}, Age: {currentRow.Age}\n";
                    }

                    return userTable;

                case '1':
                    return userDatabaseAccess.WriteToDataBase(GetNewName());

                default:
                    return "** Invalid Command Entered ** ";
	        }
        }

        public NameObject GetNewName()
        {
            NameObject enteredNameObject = new NameObject();

            Console.Write("Enter a First Name: ");
            enteredNameObject.FirstName = Console.ReadLine();
            Console.Write("Enter a Last Name: ");
            enteredNameObject.LastName = Console.ReadLine();
            Console.Write("Enter their Age: ");
            enteredNameObject.Age = Convert.ToInt32(Console.ReadLine());

            return enteredNameObject;
        }
    }
}
