namespace MedicineApi.Models
{
    public class Drug
    {
        public string Name { get; private set; }
        public string Identifier{ get; private set; }

        public Drug(string name, string identifier)
        {
            Name = name;
            Identifier = identifier;
        }
    }
}
