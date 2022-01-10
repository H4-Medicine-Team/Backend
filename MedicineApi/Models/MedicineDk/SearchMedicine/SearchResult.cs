using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk
{
    public class SearchResult
    {
        /// <summary>
        /// Results of the search
        /// </summary>
        public SearchDrugResult DrugSearchResults { get; set; }
    }
}
