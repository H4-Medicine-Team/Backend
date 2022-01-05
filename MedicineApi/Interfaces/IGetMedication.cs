﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    public interface IGetMedication<T>
    {
        public Task<T> GetMedicineByIdentifier(string dli);

        public Task<T> GetMedicineByDrugId(string drugId);

        public Task<T> GetMedicineByPackageNumberId(string packageId);
    }
}
