using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class MedicineCard
    {
        public Patient patient { get; private set; }
        public DrugMedication DrugMedication { get; private set; }
        public Organisation Organisation { get; private set; }

        public MedicineCard(Patient patient, DrugMedication drugMedication, Organisation organisation)
        {
            this.patient = patient;
            DrugMedication = drugMedication;
            Organisation = organisation;
        }
    }
}
