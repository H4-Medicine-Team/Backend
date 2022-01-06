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

        // working medicine name: para
        /// <summary>
        /// Searches for medicine with a name that matches the provided input <paramref name="medicineName"/>
        /// </summary>
        /// <returns>Returns a list of medicine</returns>
        [HttpGet("searchmedicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SearchMedicineDTO>>> SearchMedicineByName(string medicineName)
        {
            if (string.IsNullOrEmpty(medicineName))
                return BadRequest("Medicine name is required");

            try
            {
                List<SearchMedicineDTO> dtos = await _medicineDkManager.SearchMedicineByDrugName(medicineName);

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
        }

        // working drug id: 28103321701
        /// <summary>
        /// Finds medicine that matches with provided <paramref name="drugID"/>
        /// </summary>
        /// <returns>Returns a list of information about the medicin</returns>
        [HttpGet("getmedicinebydrugid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetMedicineDTO>>> GetMedicineByDrugId(string drugID)
        {
            if (string.IsNullOrEmpty(drugID))
                return BadRequest("Drug id is required");

            try
            {
                return Ok(await _medicineDkManager.GetMedicineByDrugId(drugID));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for GetMedicineByDrugId " + e.ToString());

                // Problem is code 500
                return Problem(e.Message);
            }
        }

        // working dli: 4810
        /// <summary>
        /// Finds medicine that matches with provided <paramref name="dliID"/>
        /// <br>Dli is a internal identifier used in medicine.dk</br>
        /// </summary>
        /// <returns>Returns a list of information about the medicin</returns>
        [HttpGet("getmedicinebyidentifier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetMedicineDTO>>> GetMedicineByDli(string dliID)
        {
            if (string.IsNullOrEmpty(dliID))
                return BadRequest("Identifier is required");

            try
            {
                return Ok(await _medicineDkManager.GetMedicineByIdentifier(dliID));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for GetMedicineByDli " + e.ToString());

                // Problem is code 500
                return Problem(e.Message);
            }
        }

        // working packageID: 490529
        /// <summary>
        /// Finds medicine that matches with <paramref name="packageID"/>
        /// </summary>
        /// <returns>Returns a list of information about the medicin</returns>
        [HttpGet("getmedicinebypackageid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetMedicineDTO>>> GetMedicineByPackageId(string packageID)
        {
            if (string.IsNullOrEmpty(packageID))
                return BadRequest("Package id is required");

            try
            {
                return Ok(await _medicineDkManager.GetMedicineByPackageNumberId(packageID));
            }
            catch (Exception e)
            {
                _logger.LogError("Bad request for GetMedicineByPackageID " + e.ToString());

                // Problem is code 500
                return Problem(e.Message);
            }
        }
    }
}
