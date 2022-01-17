using MedicineApi.Models.MedicineDk;
using MedicineApi.Models.MedicineDk.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public class MedicineDkManagerMock : IMedicineDkManager
    {
        private readonly MedicineDkDTOConverter _converter;
        public MedicineDkManagerMock(MedicineDkDTOConverter converter)
        {
            _converter = converter;
        }

        /// <inheritdoc />
        public async Task<List<GetMedicineDTO>> GetMedicineByDrugId(string drugId)
        {
            if (string.IsNullOrEmpty(drugId))
                throw new ArgumentException("Drug id is null or empty");

            GetResult getResult = new GetResult();
            getResult.FormattedTextFieldStructures = new GetMedicine[]
            {
                new GetMedicine
                {
                    HtmlFragment = new string[] { "<div id=\"red\">Pamol® FlashN02BE01" },
                    Id = "stamoplysninger",
                    ShowTitle = "false",
                    SpecialAttributes = null,
                    Title = "stamoplysninger"
                },
                new GetMedicine
                {
                    HtmlFragment = new string[] { "<div id=\"blue\">Pamol® Flash er et svagt smertestillende middel." },
                    Id = "indeholder",
                    ShowTitle = "true",
                    SpecialAttributes = null,
                    Title = "Indeholder"
                }
            };

            return _converter.ConvertGetResultToDtos(getResult);
        }

        /// <inheritdoc />
        public async Task<List<GetMedicineDTO>> GetMedicineByIdentifier(string dli)
        {
            if (string.IsNullOrEmpty(dli))
                throw new ArgumentException("Dli is null or empty");

            GetResult getResult = new GetResult();
            getResult.FormattedTextFieldStructures = new GetMedicine[1];

            getResult.FormattedTextFieldStructures[0] = new GetMedicine
            {
                HtmlFragment = new string[] {  },
                Id = "1235",
                ShowTitle = "false",
                SpecialAttributes = new SpecialAtribute[] { new SpecialAtribute() { Name = "key", Value = "123" } },
                Title = "Paracetamol"
            };

            return _converter.ConvertGetResultToDtos(getResult);
        }

        /// <inheritdoc />
        public async Task<MedicineIdentification> GetMedicineIdentificationWithIdentifier(string dli)
        {
            if (string.IsNullOrEmpty(dli))
                throw new ArgumentException("Dli is null or empty");

            GetResult getResult = new GetResult();
            getResult.FormattedTextFieldStructures = new GetMedicine[1];

            getResult.FormattedTextFieldStructures[0] = new GetMedicine
            {
                HtmlFragment = new string[] { },
                Id = "1235",
                ShowTitle = "false",
                SpecialAttributes = new SpecialAtribute[] { new SpecialAtribute() { Name = "key", Value = "123" } },
                Title = "Paracetamol"
            };

            MedicineIdentification getMedicineWithIdDTO = new MedicineIdentification();
            getMedicineWithIdDTO.Identifier = dli;
            getMedicineWithIdDTO.GetMedicineDTOs = _converter.ConvertGetResultToDtos(getResult);

            return getMedicineWithIdDTO;
        }
        /// <inheritdoc />
        public async Task<List<GetMedicineDTO>> GetMedicineByPackageNumberId(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
                throw new ArgumentException("Package id is null or empty");

            GetResult getResult = new GetResult();
            getResult.FormattedTextFieldStructures = new GetMedicine[1];

            getResult.FormattedTextFieldStructures[0] = new GetMedicine
            {
                HtmlFragment = new string[] { },
                Id = "1234",
                ShowTitle = "true",
                SpecialAttributes = null,
                Title = "Paracetamol"
            };

            return _converter.ConvertGetResultToDtos(getResult);
        }

        /// <inheritdoc />
        public async Task<List<SearchMedicineDTO>> SearchMedicineByDrugName(string drugName)
        {
            if (string.IsNullOrEmpty(drugName))
                throw new ArgumentException("Drug name is null or empty");


            SearchResult searchResult = new SearchResult();

            searchResult.DrugSearchResults = new SearchDrugResult();
            searchResult.DrugSearchResults.DrugSearchResult = new SearchMedicine[]
            {
                new SearchMedicine()
                {
                    ActiveSubstanceNames = new string[] { "Paracetamol" },
                    ATCCodes = new string[] { "N02BE01" },
                    Description = "Paracetamol \"B. Braun\"",
                    Drugids = new string[] { "28104851711" },
                    Identifier = "7372",
                    PackagenumberIdentifiers = new string[] { "87612", "490529" }
                },
                new SearchMedicine()
                {
                    ActiveSubstanceNames = new string[] { "Paracetamol" },
                    ATCCodes = new string[] { "N02BE01" },
                    Description = "Paracetamol \"Fresenius Kabi\"",
                    Drugids = new string[] { "28104549909" },
                    Identifier = "6649",
                    PackagenumberIdentifiers = new string[] { "54157", "453117" }
                }
            };

            return _converter.ConvertSearchResultToDtos(searchResult);
        }
    }
}
