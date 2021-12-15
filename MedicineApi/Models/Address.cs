namespace MedicineApi.Models
{
    public class Address
    {
     
        //Properties
        public int Zipcode
        {
            get;
            private set;
        }
        public string City
        {
            get;
            private set;
        }    
        public string StreetName
        {
            get;
            private set;
        }
        public string Country
        {
            get;
           private set;
        }
        //Constructor
        public Address(int zipcode, string city, string streetName, string country)
        {
            this.Zipcode = zipcode;
            this.City = city;
            this.StreetName = streetName;
            this.Country = country;
        }

    }
}
