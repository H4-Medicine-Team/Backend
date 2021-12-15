namespace MedicineApi.Models
{
    public class Organisation
    {
        public string Name { get; private set; }
        public string TelephoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string Identifier { get; private set; }

        public Organisation(string name, string telephoneNumber, string emailAddress, string identifier)
        {
            Name = name;
            TelephoneNumber = telephoneNumber;
            EmailAddress = emailAddress;
            Identifier = identifier;
        }
    }
}
