using System;

namespace MedicineApi.Models
{
    public class Interval
    {
        /// <summary>
        /// The start of the interval.
        /// </summary>
        public DateTime Start { get; private set; }

        /// <summary>
        /// When the interval is going to end.
        /// </summary>
        public DateTime End { get; private set; }

        /// <summary>
        /// The time of the day where the interval is activated.
        /// </summary>
        public DateTime ConsumptionTime { get; private set; }

        /// <summary>
        /// The days of the week where the interval is activated.
        /// </summary>
        public DayOfWeek[] Days { get; private set; }

        public Interval(DateTime start, DateTime end, DateTime consumptionTime, DayOfWeek[] days)
        {
            Start = start;
            End = end;
            ConsumptionTime = consumptionTime;
            Days = days;
        }
    }
}
