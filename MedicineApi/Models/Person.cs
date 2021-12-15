using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class Person
    {
        //properties
        public string Name { get; private set; }
        public string Surname {  get; private set; }
        public string Lastname {  get; private set; }
        public string Identifier {  get; private set; }

        //Constructor
        public Person(string name, string surname, string lastname, string identifier)
        {
            Name = name;
            Surname = surname;
            Lastname = lastname;
            Identifier = identifier;
        }



    }
}
