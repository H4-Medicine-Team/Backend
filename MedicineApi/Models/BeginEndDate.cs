using System;

namespace MedicineApi.Models
{
    public class BeginEndDate
    {
        /// <summary>
        /// The start date.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// The end date.
        /// </summary>
        public DateTime EndDate { get; private set; }

        public BeginEndDate(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
