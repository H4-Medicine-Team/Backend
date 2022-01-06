using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MedicineApi.Interfaces;

namespace MedicineApi
{
    public class MedicineDkCaller : IGetMedication<string>, ISearchMedication<string>
    {

        /// <summary>
        /// Gets medicine from medicine dk api with dli
        /// </summary>
        /// <param name="drugId"></param>
        /// <returns></returns>
        public async Task<string> GetMedicineByIdentifier(string dli)
        {
            string url = FormatUrl("MinDrugDescriptionService", "GetByDliDrugIdentifier", dli, false);

            return await GetResponse(url);
        }

        /// <summary>
        /// Gets medicine from medicine dk api with drug id
        /// </summary>
        /// <param name="drugId"></param>
        /// <returns></returns>
        public async Task<string> GetMedicineByDrugId(string drugId)
        {
            string url = FormatUrl("MinDrugDescriptionService", "GetByDrugIdentifier", drugId, false);

            return await GetResponse(url);
        }

        /// <summary>
        /// Gets medicine from medicine dk api with package id
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public async Task<string> GetMedicineByPackageNumberId(string packageId)
        {
            string url = FormatUrl("MinDrugDescriptionService", "GetByPackageNumberIdentifier", packageId, false);

            return await GetResponse(url);
        }

        /// <summary>
        /// Finds medicine from medicine dk api with drug name
        /// </summary>
        /// <param name="drugName"></param>
        /// <returns></returns>
        public async Task<string> SearchMedicineByDrugName(string drugName)
        {
            string url = FormatUrl("MinDrugSearchService", "SearchByDrugName", drugName);

            return await GetResponse(url);
        }

        /// <summary>
        /// Formats the medicine dk api link with the parameters
        /// </summary>
        /// <param name="service"></param>
        /// <param name="method"></param>
        /// <param name="parameter"></param>
        /// <param name="extraInfo"></param>
        /// <returns></returns>
        private string FormatUrl(string service, string method, string parameter, bool extraInfo = true)
        {
            if (extraInfo)
            {
                return $"https://webservices.medicin.dk/V2/MIN/Praeparat/{service}.svc/rest/{method}/Zbc-Ringsted/6f6f756c-5f00-4ca8-be67-2d2965092b2d/{parameter}/true";
            }
            else
            {
                return $"https://webservices.medicin.dk/V2/MIN/Praeparat/{service}.svc/rest/{method}/Zbc-Ringsted/6f6f756c-5f00-4ca8-be67-2d2965092b2d/{parameter}";
            }
        }

        /// <summary>
        /// Sends request to designated url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> GetResponse(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Accept", "application/json");

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (WebException we)
            {
                string resp = new StreamReader(we.Response.GetResponseStream()).ReadToEnd();

                throw new WebException(resp);
            }

            return null;
        }
    }
}
