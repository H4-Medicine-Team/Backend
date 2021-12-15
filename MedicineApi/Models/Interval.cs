using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class Interval
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public DateTime ConsumptionTime { get; private set; }
        public Days[] Days { get; private set; }

        public Interval(DateTime start, DateTime end, DateTime consumptionTime, Days[] days)
        {
            Start = start;
            End = end;
            ConsumptionTime = consumptionTime;
            Days = days;
        }
    }
}
