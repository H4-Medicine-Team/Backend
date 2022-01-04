using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    public interface ISearchMedication<T>
    {
        public Task<T> SearchMedicineByDrugName(string drugName);
    }
}
