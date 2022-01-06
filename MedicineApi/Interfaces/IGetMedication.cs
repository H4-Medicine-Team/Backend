using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    public interface IGetMedication<T>
    {
        /// <summary>
        /// Gets medicine with dli
        /// </summary>
        public Task<T> GetMedicineByIdentifier(string dli);

        /// <summary>
        /// Gets medicine with drug id
        /// </summary>
        public Task<T> GetMedicineByDrugId(string drugId);

        /// <summary>
        /// Gets medicine from medicine dk api with package id
        /// </summary>
        public Task<T> GetMedicineByPackageNumberId(string packageId);
    }
}
