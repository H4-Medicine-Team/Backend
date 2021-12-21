using MedicineApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public class DosageManager : IDosageManager
    {
        private readonly DataAccess.Dtos.MedicineContext _context;

        public DosageManager(DataAccess.Dtos.MedicineContext context) 
        {
            _context = context ?? throw new ArgumentNullException($"No db context was given {typeof(DosageManager)}");
        }

        /// <inheritdoc />
        public async Task EditReminderAsync(Dosage dosage)
        {
            
        }

        /// <inheritdoc />
        public async Task InsertReminderAsync(int drugId, Dosage dosage)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task RemoveReminderAsync(int dosageId)
        {
            throw new NotImplementedException();
        }
    }
}
