﻿using System;
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
        public async Task<string> GetMedicineByDliIdentifier(string dli)
        {
            string url = FormatUrl("MinDrugDescriptionService", "GetByDliDrugIdentifier", dli, false);

            return await GetResponse(url);
        }

        public async Task<string> GetMedicineByDruidIdentifier(string drugId)
        {
            string url = FormatUrl("MinDrugDescriptionService", "GetByDrugIdentifier", drugId, false);

            return await GetResponse(url);
        }

        public async Task<string> GetMedicineByPackageNumberIdentifier(string packageId)
        {
            string url = FormatUrl("MinDrugDescriptionService", "GetByPackageNumberIdentifier", packageId, false);

            return await GetResponse(url);
        }

        public async Task<string> SearchMedicineByDrugName(string drugName)
        {
            string url = FormatUrl("MinDrugSearchService", "SearchByDrugName", drugName);

            return await GetResponse(url);
        }

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