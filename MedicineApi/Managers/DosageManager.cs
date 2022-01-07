﻿using AutoMapper;
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
            DataAccess.Dtos.Dosage dto = _mapper.Map<DataAccess.Dtos.Dosage>(dosage);
            // DataAccess.Dtos.Interval interval = _mapper.Map<DataAccess.Dtos.Interval>(dosage.Interval);
            dto.DrugId = drugId;
            

            await _context.Dosages.AddAsync(dto);
            //await _context.Intervals.AddAsync(interval);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoveReminderAsync(int dosageId)
        {
            DataAccess.Dtos.Dosage dto = _context.Dosages.Find(dosageId);
            

            _context.Intervals.Remove(_context.Intervals.Find(dto.IntervalId));
            _context.Dosages.Remove(dto);
            await _context.SaveChangesAsync();
        }
    }
}