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
            DatabaseAccess connect = new DatabaseAccess();
            connect.connectToDatabase();
        }
    }
}
