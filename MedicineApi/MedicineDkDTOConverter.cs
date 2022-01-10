using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MedicineApi.Models.MedicineDk;
using MedicineApi.Models.MedicineDk.Dtos;

namespace MedicineApi
{
    public class MedicineDkDTOConverter
    {
        /// <summary>
        /// Converts get result to list of get medicine dto
        /// </summary>
        public List<GetMedicineDTO> ConvertGetResultToDtos(GetResult getResult)
        {
            List<GetMedicineDTO> medicineInformation = new List<GetMedicineDTO>();

            foreach(var medicine in getResult.FormattedTextFieldStructures)
            {
                GetMedicineDTO medicineDto = new GetMedicineDTO();
                medicineDto.HtmlData = new string[medicine.HtmlFragment.Length];

                for (int i = 0; i < medicine.HtmlFragment.Length; i++)
                {
                    medicineDto.HtmlData[i] = RemoveHtml(medicine.HtmlFragment[i]);
                }

                medicineDto.Id = medicine.Id;
                medicineDto.SpecialAttributes = medicine.SpecialAttributes;
                medicineDto.Title = medicine.Title;

                medicineInformation.Add(medicineDto);
            }

            return medicineInformation;
        }

        /// <summary>
        /// Converts search result to list of search medicine dto
        /// </summary>
        public List<SearchMedicineDTO> ConvertSearchResultToDtos(SearchResult searchResult)
        {
            List<SearchMedicineDTO> searchDrugDTOs = new List<SearchMedicineDTO>();

            foreach (SearchMedicine drug in searchResult.DrugSearchResults.DrugSearchResult)
            {
                SearchMedicineDTO dto = new SearchMedicineDTO
                {
                    ActiveSubstanceNames = drug.ActiveSubstanceNames,
                    ATCCodes = drug.ATCCodes,
                    Description = drug.Description,
                    Drugids = drug.Drugids,
                    Identifier = drug.Identifier,
                    PackagenumberIdentifiers = drug.PackagenumberIdentifiers
                };

                searchDrugDTOs.Add(dto);
            }

            return searchDrugDTOs;
        }

        /// <summary>
        /// Removes html tags from the string
        /// </summary>
        private string RemoveHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
