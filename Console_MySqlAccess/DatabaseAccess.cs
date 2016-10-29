using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_MySqlAccess.HiddenPass;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Console_MySqlAccess
{
    class DatabaseAccess
    {
        // Generic string for connecting to a MySql Server Database
        string myConnectionString = 
            "server=localhost;" + 
            "uid=root;" + 
            "pwd=" + ServerPass.Password() + ";" +
            "database=hello_test;";

        public void TestConnectToDatabase()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);

            MySqlCommand newCommand = connection.CreateCommand();
            newCommand.CommandText = "select * from testnames";
            connection.Open();

            MySqlDataReader reader = newCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Id: " + reader[0] + " // Name: " + reader[1] + " " + reader[2] + " //Age: " + reader[3]);
            }
            connection.Close();

            Console.Read();
        }
        public void WriteToDataBase()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand newCommand = connection.CreateCommand();

            newCommand = connection.CreateCommand();
            newCommand.CommandText = "INSERT INTO testnames (first, last, age) VALUES ('Cordelia', 'Charter', 33)";
            connection.Open();
            newCommand.ExecuteNonQuery();
            connection.Close();

            Console.Read();
        }


    }
}
