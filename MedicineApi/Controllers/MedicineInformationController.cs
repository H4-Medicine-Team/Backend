using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineApi.Models.MedicineDk;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using System.Text.Json;
using MedicineApi.Managers;
using MedicineApi.Models.MedicineDk.Dtos;

namespace MedicineApi.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class MedicineInformationController : ControllerBase
    {
        private readonly ILogger _logger;
        IMedicineDkManager _medicineDkManager;

        public MedicineInformationController(IMedicineDkManager medicineDkManager, ILogger<MedicineController> logger)
        {
            _medicineDkManager = medicineDkManager ?? throw new ArgumentNullException($"Medicine Manager was not injected {typeof(MedicineInformationController)}");
            _logger = logger ?? throw new ArgumentNullException($"Logger was not injected {typeof(MedicineInformationController)}");
        }


        [HttpGet("searchmedicine")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<SearchMedicineDTO>> SearchMedicineByName(string medicineName = "para")
        {
            if (string.IsNullOrEmpty(medicineName))
                return BadRequest("Medicine name is required");

            try
            {
                SearchResult searchResult = _medicineDkManager.SearchMedicineByDrugName(medicineName).Result;
                MedicineDkDTOConverter converter = new MedicineDkDTOConverter();

                return Ok(converter.ConvertSearchResultToDtos(searchResult));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for SearchMedicineByName " + e.ToString());

                // Problem is code 500
                return Problem("There was problem handling request");
            }

            return null;
        }

        // medicine id is found with druid of the search
        [HttpGet("getmedicinebyidentifier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetResultDTO> GetMedicineById(string medicineId = "28103321701")
        {
            if (string.IsNullOrEmpty(medicineId))
                return BadRequest("Medicin id is required");

            try
            {
                GetResult getResult = _medicineDkManager.GetMedicineByDrugIdentifier(medicineId).Result;
                MedicineDkDTOConverter converter = new MedicineDkDTOConverter();

                return Ok(converter.ConvertGetResultToDto(getResult));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for GetMedicineById " + e.ToString());

                // Problem is code 500
                return Problem(e.Message);
            }

            return null;
        }

        [HttpGet("getmedicinebypackageid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetResult> GetMedicineByPackageID(string packageId = "490529")
        {
            if (string.IsNullOrEmpty(packageId))
                return BadRequest("Package is required");

            try
            {
                GetResult getResult = _medicineDkManager.GetMedicineByPackageNumberIdentifier(packageId).Result;
                MedicineDkDTOConverter converter = new MedicineDkDTOConverter();

                return Ok(converter.ConvertGetResultToDto(getResult));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for GetMedicineByPackageID " + e.ToString());

                // Problem is code 500
                return Problem(e.Message);
            }

            return null;
        }

    }
}
