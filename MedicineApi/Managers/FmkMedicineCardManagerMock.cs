﻿using MedicineApi.Models;
using System;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public class FmkMedicineCardManagerMock : IMedicineCardManager
    {
        /// <summary>
        /// Returns a mock object of the medicinecard
        /// </summary>
        /// <param name="cprNumber">Is not used in the mock object</param>
        /// <returns>A mock object of medicinecard</returns>
        public Task<MedicineCard> GetMedicineCardAsync(string cprNumber)
        {
            Person person = new Person("Gurli", "Gris", "Grisen", "1111111111");
            Address address = new Address(2630, "Taastrup", "Kingosvej 1", "Denmark");
            Patient patient = new Patient(person, address);

            Days[] days =
            {
                Days.Monday,
                Days.Tuesday,
                Days.Wednesday,
                Days.Thursday,
                Days.Friday,
                Days.Saturday,
                Days.Sunday
            };
            Interval interval = new Interval(DateTime.Now, DateTime.Now.AddDays(2), DateTime.Now.AddMinutes(10), days);
            Dosage dosage = new Dosage(2, AmountType.Pieces, interval);

            Drug drug = new Drug("Minulet", "1232321231");
            BeginEndDate bed = new BeginEndDate(DateTime.Now, DateTime.Now.AddDays(2));
            DrugMedication medication = new DrugMedication(dosage, drug, bed, "123123123123");

            Organisation organisation = new Organisation("Apotek", "4352525252", "Apotek@mail.dk", "123451231");

            MedicineCard card = new MedicineCard(patient, medication, organisation);

            return Task.Run(() => { return card; });
        }
    }
}