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
            
        }

        /// <inheritdoc />
        public async Task InsertReminderAsync(int drugId, Dosage dosage)
        {
            DataAccess.Dtos.Dosage dto = _mapper.Map<DataAccess.Dtos.Dosage>(dosage);
            dto.DrugId = drugId;

            //await _context.Dosages.AddAsync(dto);
            //await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoveReminderAsync(int dosageId)
        {
            throw new NotImplementedException();
        }
    }
}
