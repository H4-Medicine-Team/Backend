using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class DrugMedication
    {
        public Dosage Dosage { get; private set; }
        public Drug Drug { get; private set; }
        public BeginEndDate BeginEndDate { get; private set; }
        public string Identifier { get; private set; }

        public DrugMedication(Dosage dosage, Drug drug, BeginEndDate beginEndDate, string identifier)
        {
            Dosage = dosage;
            Drug = drug;
            BeginEndDate = beginEndDate;
            Identifier = identifier;
        }
    }
}
