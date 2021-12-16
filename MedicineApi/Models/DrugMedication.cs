using System.Collections.Generic;

namespace MedicineApi.Models
{
    public class DrugMedication
    {
        /// <summary>
        /// The list of dosages for this medication.
        /// </summary>
        public List<Dosage> Dosage { get; private set; }

        /// <summary>
        /// The description of the drug.
        /// </summary>
        public Drug Drug { get; private set; }

        /// <summary>
        /// When the medicine was starting to be issued, and when the medication is ending.
        /// </summary>
        public BeginEndDate BeginEndDate { get; private set; }

        /// <summary>
        /// The unique id of the medication.
        /// </summary>
        public string Identifier { get; private set; }

        public DrugMedication(List<Dosage> dosage, Drug drug, BeginEndDate beginEndDate, string identifier)
        {
            Dosage = dosage;
            Drug = drug;
            BeginEndDate = beginEndDate;
            Identifier = identifier;
        }
    }
}
