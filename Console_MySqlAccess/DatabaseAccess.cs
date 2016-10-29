using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Console_MySqlAccess
{
    class DatabaseAccess
    {
        public void connectToDatabase()
        {
            string myConnectionString = "server=localhost;uid=root;pwd=;database=hello_test;";

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

            /*
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex);
                Console.Read();
            }
            */
            Console.Read();

            newCommand = connection.CreateCommand();
            newCommand.CommandText = "INSERT INTO testnames (first, last, age) VALUES ('Cordelia', 'Charter', 33)";
            connection.Open();
            newCommand.ExecuteNonQuery();

            connection.Close();
            Console.Read();
        }
    }
}
