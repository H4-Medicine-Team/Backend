using MedicineApi.Managers;
using MedicineApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MedicineApi.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineCardManager _medicineCardManager;
        private readonly ILogger _logger;

        public MedicineController(IMedicineCardManager medicineCardManager, ILogger<MedicineController> logger)
        {
            _medicineCardManager = medicineCardManager ?? throw new ArgumentNullException($"Medicine Manager was not injected {typeof(MedicineController)}");
            _logger = logger ?? throw new ArgumentNullException($"Logger was not injected {typeof(MedicineController)}");
        }

        /// <summary>
        /// Retrieves a medicinecard for the given user.
        /// </summary>
        /// <param name="cprNumber">The users cpr numbers</param>
        /// <returns>The medicinecard specified by the cpr number</returns>
        [HttpGet("medicinecard")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicineCard>> GetMedicineCardAsync(string cprNumber)
        {
            if (string.IsNullOrEmpty(cprNumber))
                return BadRequest("Cpr number was not correct");

            try
            {
                return await _medicineCardManager.GetMedicineCardAsync(cprNumber);
                
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for GetMedicineCard " + e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request GetMedicineCard " + e.Message);
                return Problem(e.Message, e.Source, 500, e.InnerException.HResult.ToString());
            }
        }

    }
}
