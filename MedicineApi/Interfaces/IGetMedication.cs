using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    public interface IGetMedication<T>
    {
        public Task<T> GetMedicineByDliIdentifier(string dli);

        public Task<T> GetMedicineByDruidIdentifier(string druidId);

        public Task<T> GetMedicineByPackageNumberIdentifier(string packageId);
    }
}
