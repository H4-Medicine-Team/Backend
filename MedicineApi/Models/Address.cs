namespace MedicineApi.Models
{
    public class Address
    {
        /// <summary>
        /// Zipcode for the regional.
        /// ex: 2630.
        /// </summary>
        public int Zipcode { get; private set; }

        /// <summary>
        /// The name of the city.
        /// Ex: Taastrup.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// The streetname in the city.
        /// ex: Kingosvej, Kingosvej 31
        /// </summary>
        public string StreetName { get; private set; }

        /// <summary>
        /// The country.
        /// ex: Denmark
        /// </summary>
        public string Country { get; private set; }

        public Address(int zipcode, string city, string streetName, string country)
        {
            Zipcode = zipcode;
            City = city;
            StreetName = streetName;
            Country = country;
        }

    }
}
