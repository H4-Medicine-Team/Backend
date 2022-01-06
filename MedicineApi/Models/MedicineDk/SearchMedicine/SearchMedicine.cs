using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk
{
    public class SearchMedicine
    {
        /// <summary>
        /// Identifier of the medicine
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Description of the medicine
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ATC Codes  of the medicine
        /// </summary>
        public string[] ATCCodes { get; set; }

        /// <summary>
        /// Substance names of the medicine
        /// </summary>
        public string[] ActiveSubstanceNames { get; set; }

        /// <summary>
        /// Drug ids of the medicine
        /// /// </summary>
        public string[] Drugids { get; set; }

        /// <summary>
        /// Package numbers of the medicine
        /// </summary>
        public string[] PackagenumberIdentifiers { get; set; }
    }
}
