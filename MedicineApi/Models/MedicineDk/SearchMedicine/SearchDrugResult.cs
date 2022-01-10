using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk
{
    public class SearchDrugResult
    {
        /// <summary>
        /// Medicine found
        /// </summary>
        public SearchMedicine[] DrugSearchResult { get; set; }
    }
}
