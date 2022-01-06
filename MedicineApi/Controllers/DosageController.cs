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
    public class DosageController : ControllerBase
    {
        private readonly IDosageManager _dosageManager;
        private readonly ILogger _logger;

        public DosageController(IDosageManager dosageManager, ILogger<DosageController> logger)
        {
            _dosageManager = dosageManager ?? throw new ArgumentNullException($"Dosagemanager was not injected {typeof(DosageController)}");
            _logger = logger ?? throw new ArgumentNullException($"Logger was not injected {typeof(DosageController)}");
        }


        /// <summary>
        /// Removes the referenced dosage id with all its linked contents in the database.
        /// </summary>
        /// <param name="dosageId">The id reference to remove.</param>
        /// <returns>Status code for execution.</returns>
        [HttpDelete("reminder")]
        public async Task<IActionResult> RemoveReminderAsync(int dosageId)
        {
            try
            {
                await _dosageManager.RemoveReminderAsync(dosageId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request RemoveReminderAsync " + e.Message);
                return Problem(e.Message, e.Source, 500, e.HResult.ToString());
            }
        }


        /// <summary>
        /// Edits a dosage reminder, by editing the details in the dosage object and putting it into the database.
        /// </summary>
        /// <param name="dosage">The edited object to put into database.</param>
        /// <returns>Status code for execution.</returns>
        [HttpPut("reminder")]
        public async Task<IActionResult> EditReminderAsync(Dosage dosage)
        {
            try
            {
                await _dosageManager.EditReminderAsync(dosage);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request EditReminderAsync " + e.Message);
                return Problem(e.Message, e.Source, 500, e.InnerException.HResult.ToString());
            }
        }


        /// <summary>
        /// Inserts the dosage reminder object into the database.
        /// </summary>
        /// <param name="drugId">The drug id the reminder should reference</param>
        /// <param name="dosage">The dosage reminder to insert.</param>
        /// <returns>Status code for execution.</returns>
        [HttpPost("reminder")]
        public async Task<IActionResult> InsertReminderAsync(int drugId, Dosage dosage)
        {
            try
            {
                await _dosageManager.InsertReminderAsync(drugId, dosage);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request InsertReminderAsync " + e.Message);
                return Problem(e.Message, e.Source, 500, e.InnerException.HResult.ToString());
            }
        }

    }
}
