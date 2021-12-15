using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class BeginEndDate
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public BeginEndDate(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
