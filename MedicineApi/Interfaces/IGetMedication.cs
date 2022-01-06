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
        /// <param name="dli"></param>
        /// <returns></returns>
        public Task<T> GetMedicineByIdentifier(string dli);

        /// <summary>
        /// Gets medicine with drug id
        /// </summary>
        /// <param name="drugId"></param>
        /// <returns></returns>
        public Task<T> GetMedicineByDrugId(string drugId);

        /// <summary>
        /// Gets medicine from medicine dk api with package id
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public Task<T> GetMedicineByPackageNumberId(string packageId);
    }
}
