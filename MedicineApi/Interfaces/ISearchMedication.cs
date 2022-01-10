using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    public interface ISearchMedication<T>
    {
        /// <summary>
        /// Finds medicine with that drug name
        /// </summary>
        public Task<T> SearchMedicineByDrugName(string drugName);
    }
}
