namespace MedicineApi.Models
{
    public class Organisation
    {
        /// <summary>
        /// The name of the organisation.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The phone number of the organisation.
        /// </summary>
        public string TelephoneNumber { get; private set; }

        /// <summary>
        /// The email address of the organisation.
        /// </summary>
        public string EmailAddress { get; private set; }

        /// <summary>
        /// The unique id of the organisation.
        /// </summary>
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
