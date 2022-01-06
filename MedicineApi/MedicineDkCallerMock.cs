using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MedicineApi.Interfaces;

namespace MedicineApi
{
    public class MedicineDkCallerMock : IGetMedication<string>
    {
        /// <inheritdoc />
        public Task<string> GetMedicineByDrugId(string drugId)
        {
            if (drugId == "Does not exist")
                throw new WebException("602 InvalidDrugIdentifier: (DrugIdentifier)");

            return Task.Run(() => { return "{}"; });
        }

        /// <inheritdoc />
        public Task<string> GetMedicineByIdentifier(string dli)
        {
            if (dli == "Does not exist")
                throw new WebException("One or more errors occurred. (\"404 EntityNotFound\")");

            return Task.Run(() => { return "{}"; });
        }

        /// <inheritdoc />
        public Task<string> GetMedicineByPackageNumberId(string packageId)
        {
            if (packageId == "Does not exist")
                throw new WebException("One or more errors occurred. (\"404 EntityNotFound\")");

            return Task.Run(() => { return "{}"; });
        }
    }
}
