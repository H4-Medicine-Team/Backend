using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    public interface IGetMedicationWithId<T>
    {
        /// <summary>
        /// Gets medicine with drug id
        /// </summary>
        public Task<T> GetMedicineIdentificationWithIdentifier(string drugId);

    }
}
