using AutoMapper;
using MedicineApi.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Gets all dosage by user id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private List<Dosage> GetAllDosagesById(int userid)
        {
            List<Dosage> dosages = new List<Dosage>();
            var sqlParameter = new SqlParameter("@UserID", userid);
            using (var cnn = _context.Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "[dbo].[GetIntervalForToday]";
                cmm.Parameters.Add(sqlParameter);
                cmm.Connection = cnn;
                cnn.Open();
                var reader = cmm.ExecuteReader();

                DataAccess.Dtos.Day day = new DataAccess.Dtos.Day();
                while (reader.Read())
                {
                    day.Sunday = (reader["Sunday"])as bool? ?? false;
                    day.Monday = (reader["Monday"]) as bool? ?? false;
                    day.Tuesday = (reader["Tuesday"]) as bool? ?? false;
                    day.Wednesday = (reader["Wednesday"]) as bool? ?? false;
                    day.Thursday = (reader["Thursday"]) as bool? ?? false;
                    day.Friday = (reader["Friday"]) as bool? ?? false;
                    day.Saturday = (reader["Saturday"]) as bool? ?? false;

                    dosages.Add(new Dosage((int)reader["amount"], 
                                (AmountType)Enum.Parse(typeof(AmountType), reader["amountType"].ToString()), 
                                new Interval(DateTime.Parse(reader["start_time"].ToString()),
                                DateTime.Parse(reader["end_time"].ToString()),
                                DateTime.Parse(reader["consumption_time"].ToString()),
                                _mapper.Map<DayOfWeek[]>(day))));
                }
            }
            return dosages;
        }

        /// <summary>
        /// Returnes the newst reminder from all the reminders.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private Dosage GetNewestReminder(int userid)
        {
            Dosage nextDosage = new();
            List<Dosage> dosages = GetAllDosagesById(userid);
            DateTime now = DateTime.Now;
            DateTime tempClosestTime = DateTime.MaxValue;
            for (int i = 0; i < dosages.Count; i++)
            {
                if (dosages[i].Interval.ConsumptionTime.Ticks > now.Ticks)
                {
                    if (dosages[i].Interval.ConsumptionTime.Ticks > now.Ticks && dosages[i].Interval.ConsumptionTime.Ticks < tempClosestTime.Ticks)
                    {
                        tempClosestTime = dosages[i].Interval.ConsumptionTime;
                        nextDosage = dosages[i];
                    }
                }
            }
            return nextDosage;
        }

        /// <inheritdoc/>
        public async Task<Dosage> GetLatesReminderById(int userid)
        {
            if (userid < 0)
                throw new ArgumentOutOfRangeException("Userid cannot be less then 0");

            return GetNewestReminder(userid);
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
        public async Task InsertReminderAsync(int drugId, Dosage dosage, int userid)
        {
            if (userid < 0)
                throw new ArgumentOutOfRangeException("Userid cannot be less then 0");

            if (dosage is null)
                throw new ArgumentNullException("Dosage is null");

            if (drugId < 0)
                throw new ArgumentOutOfRangeException("DrugId cannot be less than 0");

            DataAccess.Dtos.Dosage dto = _mapper.Map<DataAccess.Dtos.Dosage>(dosage);
            dto.DrugId = drugId;
            dto.UserId = userid;
            

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
