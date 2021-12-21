namespace MedicineApi.Models
{
    public class Person
    {

        /// <summary>
        /// The first name of the person.
        /// ex: John
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The surname of the person.
        /// ex: Doe
        /// </summary>
        public string Surname {  get; private set; }

        /// <summary>
        /// The lastname of the person
        /// ex: Andersen
        /// </summary>
        public string Lastname {  get; private set; }

        /// <summary>
        /// The unique id of the person.
        /// ex: Cpr number: 111111-1111
        /// </summary>
        public string Identifier {  get; private set; }

        public Person(string name, string surname, string lastname, string identifier)
        {
            Name = name;
            Surname = surname;
            Lastname = lastname;
            Identifier = identifier;
        }



    }
}
