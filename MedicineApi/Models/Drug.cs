namespace MedicineApi.Models
{
    public class Drug
    {
        /// <summary>
        /// The name of the drug
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The unique id which identifies a drug.
        /// </summary>
        public string Identifier{ get; private set; }

        public Drug(string name, string identifier)
        {
            Name = name;
            Identifier = identifier;
        }
    }
}
