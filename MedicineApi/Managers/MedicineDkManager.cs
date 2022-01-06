using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MedicineApi.Models;
using MedicineApi.Models.MedicineDk;
using MedicineApi.Interfaces;

namespace MedicineApi.Managers
{
    public class MedicineDkManager : IMedicineDkManager
    {
        private readonly MedicineDkCaller _caller;

        public MedicineDkManager(MedicineDkCaller caller)
        {
            _caller = caller;
        }

        public Task<GetResult> GetMedicineByIdentifier(string dli)
        {
            if (string.IsNullOrEmpty(dli))
                throw new ArgumentException("Dli is null or empty");

            string searchRes = _caller.GetMedicineByIdentifier(dli).Result;

            GetResult searchResult = JsonSerializer.Deserialize<GetResult>(searchRes);

            return Task.Run(() => { return searchResult; });
        }

        public Task<GetResult> GetMedicineByDrugId(string drugId)
        {
            if (string.IsNullOrEmpty(drugId))
                throw new ArgumentException("Drug id is null or empty");

            string searchRes = _caller.GetMedicineByDrugId(drugId).Result;

            GetResult searchResult = JsonSerializer.Deserialize<GetResult>(searchRes);

            return Task.Run(() => { return searchResult; });
        }

        public Task<GetResult> GetMedicineByPackageNumberId(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
                throw new ArgumentException("Package id is null or empty");

            string searchRes = _caller.GetMedicineByPackageNumberId(packageId).Result;

            GetResult searchResult = JsonSerializer.Deserialize<GetResult>(searchRes);        

            return Task.Run(() => { return searchResult; });
        }
        public Task<SearchResult> SearchMedicineByDrugName(string drugName)
        {
            if (string.IsNullOrEmpty(drugName))
                throw new ArgumentException("Drug name is null or empty");

            string searchRes = _caller.SearchMedicineByDrugName(drugName).Result;

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(searchRes);

            return Task.Run(() => { return searchResult; });
        }
    }
}
