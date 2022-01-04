using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk.Dtos
{
    public class SearchMedicineDTO
    {
        public string Identifier { get; set; }
        public string Description { get; set; }
        public string[] ATCCodes { get; set; }
        public string[] ActiveSubstanceNames { get; set; }
        public string[] Drugids { get; set; }
        public string[] PackagenumberIdentifiers { get; set; }
    }
}
