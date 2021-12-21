using MedicineApi.Models;
using System;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public class DosageManager : IDosageManager
    {
        public DosageManager() {}

        /// <inheritdoc />
        public Task EditReminderAsync(Dosage dosage)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task InsertReminderAsync(int drugId, Dosage dosage)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task RemoveReminderAsync(int dosageId)
        {
            throw new NotImplementedException();
        }
    }
}
