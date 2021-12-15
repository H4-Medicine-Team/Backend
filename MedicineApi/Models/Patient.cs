using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class Patient
    {
        public Person Person { get; private set; }
        public Address Address { get; private set; }

        public Patient(Person person, Address address)
        {
            Person = person;
            Address = address;
        }
    }
}
