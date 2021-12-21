using System.Collections.Generic;

namespace MedicineApi.Models
{
    public class MedicineCard
    {
        /// <summary>
        /// Refers to the patient for this medicinecard.
        /// </summary>
        public Patient Patient { get; private set; }

        /// <summary>
        /// Refers to the list of medication the patient has.
        /// </summary>
        public List<DrugMedication> DrugMedication { get; private set; }

        /// <summary>
        /// Refers to the organisation which have a relation to the patient.
        /// </summary>
        public Organisation Organisation { get; private set; }

        public MedicineCard(Patient patient, List<DrugMedication> drugMedication, Organisation organisation)
        {
            Patient = patient;
            DrugMedication = drugMedication;
            Organisation = organisation;
        }
    }
}
