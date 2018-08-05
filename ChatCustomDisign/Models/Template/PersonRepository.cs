using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCustomDisign.Models.Template
{
    public class PersonRepository
    {
        private static ObservableCollection<Person> _people;

        public static ObservableCollection<Person> AllClients
        {
            get
            {
                if (_people == null)
                    _people = GenerateClientRepository();
                return _people;
            }
        }

        private static ObservableCollection<Person> GenerateClientRepository()
        {
            ObservableCollection<Person> clients = new ObservableCollection<Person>
            {
                new Person("Jhon", "Doe"),
                new Person("Tom", "Ronald"),
                new Person("Jane", "Roe"),
            };
            return clients;
        }
    }
}
