using MedicineApi.Models;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public interface IDosageManager
    {
        /// <summary>
        /// Inserts a dosage reminder into the database, referincing the given drug id.
        /// </summary>
        /// <param name="drugId">The drug id to reference.</param>
        /// <param name="dosage">The dosage reminder to insert</param>
        Task InsertReminderAsync(int drugId, Dosage dosage);

        /// <summary>
        /// Edits a dosage reminder in the database
        /// </summary>
        /// <param name="dosage">The edited dosage</param>
        Task EditReminderAsync(Dosage dosage);

        /// <summary>
        /// Removes the dosage reminder by the referenced id in the database.
        /// </summary>
        /// <param name="dosageId">The id to remove</param>
        Task RemoveReminderAsync(int dosageId);
    }
}
