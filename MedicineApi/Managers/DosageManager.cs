using AutoMapper;
using MedicineApi.Models;
using System;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public class DosageManager : IDosageManager
    {
        private readonly DataAccess.Dtos.MedicineContext _context;
        private readonly IMapper _mapper;

        public DosageManager(DataAccess.Dtos.MedicineContext context, IMapper mapper) 
        {
            _context = context ?? throw new ArgumentNullException($"No db context was given {typeof(DosageManager)}");
            _mapper = mapper ?? throw new ArgumentNullException($"No mapper was given {typeof(DosageManager)}");
        }

        /// <inheritdoc />
        public async Task EditReminderAsync(Dosage dosage)
        {
            if (dosage is null)
                throw new ArgumentNullException("Dosage was null");

            if (dosage.Interval is null)
                throw new ArgumentNullException("Interval in dosage was null");

            if (dosage.Amount < 0)
                throw new ArgumentOutOfRangeException("Amount cannot be less than 0");

            DataAccess.Dtos.Dosage dto = _mapper.Map<DataAccess.Dtos.Dosage>(dosage);

            var resault = _context.Dosages.Find(dto.Id);
            if (resault != null)
            {
                resault.Interval = dto.Interval;
                resault.AmountType = dto.AmountType;
                resault.Amount = dto.Amount;
                await _context.SaveChangesAsync();
                
            }
        }

        /// <inheritdoc />
        public async Task InsertReminderAsync(int drugId, Dosage dosage)
        {
            if (dosage is null)
                throw new ArgumentNullException("Dosage is null");

            if (drugId < 0)
                throw new ArgumentOutOfRangeException("DrugId cannot be less than 0");

            DataAccess.Dtos.Dosage dto = _mapper.Map<DataAccess.Dtos.Dosage>(dosage);
            dto.DrugId = drugId;
            

            await _context.Dosages.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoveReminderAsync(int dosageId)
        {
            if (dosageId < 0)
                throw new ArgumentOutOfRangeException("DosageId cannot be less than 0");

            DataAccess.Dtos.Dosage dto = _context.Dosages.Find(dosageId);

            _context.Intervals.Remove(_context.Intervals.Find(dto.IntervalId));
            _context.Dosages.Remove(dto);
            await _context.SaveChangesAsync();
        }
    }
}
