using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    public interface IGetMedication<T>
    {
        public Task<T> GetMedicineByDrugIdentifier(string drugId);

        public Task<T> GetMedicineByPackageNumberIdentifier(string packageId);
    }
}
