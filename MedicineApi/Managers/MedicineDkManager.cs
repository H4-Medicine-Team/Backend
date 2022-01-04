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
        MedicineDkCaller caller;

        public MedicineDkManager()
        {
            caller = new MedicineDkCaller();
        }

        public Task<GetResult> GetMedicineByDliIdentifier(string dli)
        {
            string searchRes = caller.GetMedicineByDliIdentifier(dli).Result;

            GetResult searchResult = JsonSerializer.Deserialize<GetResult>(searchRes);

            return Task.Run(() => { return searchResult; });
        }

        public Task<GetResult> GetMedicineByDruidIdentifier(string druidId)
        {
            string searchRes = caller.GetMedicineByDruidIdentifier(druidId).Result;

            GetResult searchResult = JsonSerializer.Deserialize<GetResult>(searchRes);

            return Task.Run(() => { return searchResult; });
        }

        public Task<GetResult> GetMedicineByPackageNumberIdentifier(string packageId)
        {
            string searchRes = caller.GetMedicineByPackageNumberIdentifier(packageId).Result;

            GetResult searchResult = JsonSerializer.Deserialize<GetResult>(searchRes);        

            return Task.Run(() => { return searchResult; });
        }
        public Task<SearchResult> SearchMedicineByDrugName(string drugName)
        {
            string searchRes = caller.SearchMedicineByDrugName(drugName).Result;

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(searchRes);

            return Task.Run(() => { return searchResult; });
        }
    }
}
