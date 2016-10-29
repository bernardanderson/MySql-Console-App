using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_MySqlAccess.HiddenPass;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Console_MySqlAccess.MySqlCommands
{
    class DatabaseAccess
    {
        // Generic string for connecting to a MySql Server Database
        string myConnectionString = 
            "server=localhost;" + 
            "uid=root;" + 
            "pwd=" + ServerPass.Password() + ";" +
            "database=hello_test;";

        public List<NameObject> GetAllNamesFromDatabase()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand newCommand = connection.CreateCommand();
            newCommand.CommandText = "select * from testnames";

            connection.Open();

            MySqlDataReader reader = newCommand.ExecuteReader();

            List<NameObject> listOfNames = new List<NameObject>();

            while (reader.Read())
            {
                NameObject currentDatabaseRow = new NameObject(
                    Convert.ToInt32(reader[0]), 
                    reader[1].ToString(), 
                    reader[2].ToString(), 
                    Convert.ToInt32(reader[3]));

                listOfNames.Add(currentDatabaseRow);
            }
            connection.Close();

            return listOfNames;
        }

        public string WriteToDataBase(NameObject sentNewName)
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand newCommand = connection.CreateCommand();

            newCommand = connection.CreateCommand();
            newCommand.CommandText = $"INSERT INTO testnames (first, last, age) VALUES ('{sentNewName.FirstName}', '{sentNewName.LastName}', {sentNewName.Age})";
            connection.Open();
            newCommand.ExecuteNonQuery();
            connection.Close();

            return "** New Name Added **";
        }

        public string DeleteNameRow(int sentNameIDToDelete)
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand newCommand = connection.CreateCommand();

            newCommand = connection.CreateCommand();
            newCommand.CommandText = $"DELETE FROM testnames WHERE id = {sentNameIDToDelete}";
            connection.Open();
            newCommand.ExecuteNonQuery();
            connection.Close();

            return $"** Name with ID of {sentNameIDToDelete} Deleted **";
        }

    }
}
