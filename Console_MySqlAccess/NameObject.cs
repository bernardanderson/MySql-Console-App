using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_MySqlAccess
{
    public class NameObject
    {
        public int NameID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public NameObject() { }

        public NameObject(int nameId, string firstName, string lastName, int age)
        {
            this.NameID = nameId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
