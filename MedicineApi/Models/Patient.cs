namespace MedicineApi.Models
{
    public class Patient
    {
        /// <summary>
        /// The description of the patient.
        /// </summary>
        public Person Person { get; private set; }

        /// <summary>
        /// The address of the patient.
        /// </summary>
        public Address Address { get; private set; }

        public Patient(Person person, Address address)
        {
            Person = person;
            Address = address;
        }
    }
}
