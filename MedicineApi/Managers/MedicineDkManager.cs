using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MedicineApi.Models;
using MedicineApi.Models.MedicineDk;
using MedicineApi.Interfaces;
using MedicineApi.Models.MedicineDk.Dtos;

namespace MedicineApi.Managers
{
    public class MedicineDkManager : IMedicineDkManager
    {
        private readonly MedicineDkCaller _caller;
        private readonly MedicineDkDTOConverter _converter;

        public MedicineDkManager(MedicineDkCaller caller, MedicineDkDTOConverter converter)
        {
            _caller = caller;
            _converter = converter;
        }

        /// <inheritdoc />
        public async Task<List<GetMedicineDTO>> GetMedicineByIdentifier(string dli)
        {
            if (string.IsNullOrEmpty(dli))
                throw new ArgumentException("Dli is null or empty");

            string getRes = await _caller.GetMedicineByIdentifier(dli);

            GetResult getResult = JsonSerializer.Deserialize<GetResult>(getRes);

            return _converter.ConvertGetResultToDtos(getResult);
        }

        /// <inheritdoc />
        public async Task<GetMedicineWithId> GetMedicineDrugByIdentifier(string dli)
        {
            if (string.IsNullOrEmpty(dli))
                throw new ArgumentException("Drug id is null or empty");

            string getRes = await _caller.GetMedicineByIdentifier(dli);

            GetResult getResult = JsonSerializer.Deserialize<GetResult>(getRes);

            GetMedicineWithId getMedicineWithIdDTO = new GetMedicineWithId();
            getMedicineWithIdDTO.Identifier = dli;
            getMedicineWithIdDTO.GetMedicineDTOs = _converter.ConvertGetResultToDtos(getResult);

            return getMedicineWithIdDTO;
        }

        /// <inheritdoc />
        public async Task<List<GetMedicineDTO>> GetMedicineByDrugId(string drugId)
        {
            if (string.IsNullOrEmpty(drugId))
                throw new ArgumentException("Drug id is null or empty");

            string getRes = await _caller.GetMedicineByDrugId(drugId);

            GetResult getResult = JsonSerializer.Deserialize<GetResult>(getRes);

            return _converter.ConvertGetResultToDtos(getResult);
        }
       

        /// <inheritdoc />
        public async Task<List<GetMedicineDTO>> GetMedicineByPackageNumberId(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
                throw new ArgumentException("Package id is null or empty");

            string getRes = await _caller.GetMedicineByPackageNumberId(packageId);

            GetResult getResult = JsonSerializer.Deserialize<GetResult>(getRes);

            return _converter.ConvertGetResultToDtos(getResult);
        }
        /// <inheritdoc />
        public async Task<List<SearchMedicineDTO>> SearchMedicineByDrugName(string drugName)
        {
            if (string.IsNullOrEmpty(drugName))
                throw new ArgumentException("Drug name is null or empty");

            string searchRes = await _caller.SearchMedicineByDrugName(drugName);

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(searchRes);

            return _converter.ConvertSearchResultToDtos(searchResult);
        }
    }
}
