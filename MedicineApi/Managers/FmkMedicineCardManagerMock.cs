using MedicineApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public class FmkMedicineCardManagerMock : IMedicineCardManager
    {
        public FmkMedicineCardManagerMock()
        {
        }

        /// <inheritdoc />
        public Task<MedicineCard> GetMedicineCardAsync(string cprNumber)
        {
            if (string.IsNullOrEmpty(cprNumber))
                throw new ArgumentException("Cpr number was null or empty");

            if (cprNumber.Contains('-'))
                cprNumber = cprNumber.Replace("-", "");

            if (cprNumber.Length < 10)
                throw new ArgumentOutOfRangeException("Cpr number is not valid");

            Person person = new Person("Gurli", "Gris", "Grisen", "1111111111");
            Address address = new Address(2630, "Taastrup", "Kingosvej 1", "Denmark");
            Patient patient = new Patient(person, address);

            DayOfWeek[] days =
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
            Interval interval = new Interval(DateTime.Now, DateTime.Now.AddDays(2), DateTime.Now.AddMinutes(10), days);
            Dosage dosage = new Dosage(2, AmountType.Pieces, interval);

            BeginEndDate bed = new BeginEndDate(DateTime.Now, DateTime.Now.AddDays(2));
            
            Drug drug = new Drug("Minulet", "4810");
            DrugMedication medication = new DrugMedication(new List<Dosage>() { dosage }, drug, bed, "123123123123");

            Drug drug2 = new Drug("Citalopram \"Mylan\"", "8036");
            DrugMedication medication2 = new DrugMedication(new List<Dosage>() { dosage }, drug2, bed, "123123123123");

            Drug drug3 = new Drug("Dolol", "1986");
            DrugMedication medication3 = new DrugMedication(new List<Dosage>() { dosage }, drug3, bed, "123123123123");

            Organisation organisation = new Organisation("Apotek", "4352525252", "Apotek@mail.dk", "123451231");

            MedicineCard card = new MedicineCard(patient, new List<DrugMedication>() { medication, medication2, medication3 }, organisation);

            return Task.Run(() => { return card; });
        }
    }
}
