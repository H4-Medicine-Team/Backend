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

        public MedicineInformationController(IMedicineDkManager medicineDkManager, ILogger<MedicineInformationController> logger)
        {
            _medicineDkManager = medicineDkManager ?? throw new ArgumentNullException($"Medicine Manager was not injected {typeof(MedicineInformationController)}");
            _logger = logger ?? throw new ArgumentNullException($"Logger was not injected {typeof(MedicineInformationController)}");
        }

        /// <summary>
        /// Searches for specific medicin with that name
        /// </summary>
        /// <param name="medicineName">param</param>
        /// <returns></returns>
        [HttpGet("searchmedicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<SearchMedicineDTO>> SearchMedicineByName(string medicineName = "para")
        {
            if (string.IsNullOrEmpty(medicineName))
                return BadRequest("Medicine name is required");

            try
            {
                SearchResult searchResult = _medicineDkManager.SearchMedicineByDrugName(medicineName).Result;
                MedicineDkDTOConverter converter = new MedicineDkDTOConverter();

                List<SearchMedicineDTO> dtos = converter.ConvertSearchResultToDtos(searchResult);

                if (dtos.Count == 0)
                    return NotFound("No medicine found with that name");

                return Ok(dtos);
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for SearchMedicineByName " + e.ToString());

                // Problem is code 500
                return Problem("There was problem handling request");
            }

            return null;
        }

        [HttpGet("getmedicinebydrugid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<GetMedicineDTO>> GetMedicineByDrugId(string drugID = "28103321701")
        {
            if (string.IsNullOrEmpty(drugID))
                return BadRequest("Medicin id is required");

            try
            {
                GetResult getResult = _medicineDkManager.GetMedicineByDrugId(drugID).Result;
                MedicineDkDTOConverter converter = new MedicineDkDTOConverter();

                return Ok(converter.ConvertGetResultToDtos(getResult));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for GetMedicineById " + e.ToString());

                // Problem is code 500
                return Problem(e.Message);
            }

            return null;
        }

        // its dli identifier
        [HttpGet("getmedicinebyidentifier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<GetMedicineDTO>> GetMedicineByDli(string dliID = "4810")
        {
            if (string.IsNullOrEmpty(dliID))
                return BadRequest("Package is required");

            try
            {
                GetResult getResult = _medicineDkManager.GetMedicineByIdentifier(dliID).Result;
                MedicineDkDTOConverter converter = new MedicineDkDTOConverter();

                return Ok(converter.ConvertGetResultToDtos(getResult));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for GetMedicineByDli " + e.ToString());

                // Problem is code 500
                return Problem(e.Message);
            }

            return null;
        }

        [HttpGet("getmedicinebypackageid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<GetMedicineDTO>> GetMedicineByPackageId(string packageID = "490529")
        {
            if (string.IsNullOrEmpty(packageID))
                return BadRequest("Package is required");

            try
            {
                GetResult getResult = _medicineDkManager.GetMedicineByPackageNumberId(packageID).Result;
                MedicineDkDTOConverter converter = new MedicineDkDTOConverter();

                return Ok(converter.ConvertGetResultToDtos(getResult));
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
