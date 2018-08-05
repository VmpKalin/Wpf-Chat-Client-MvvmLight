using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCustomDisign.Models.Template
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<UserChat> Chats { get; set; }
        
        public Person()
        {
        }

        public Person(string firstName, string lastName, List<UserChat> chats)
        {
            FirstName = firstName;
            LastName = lastName;
            Chats = chats;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
