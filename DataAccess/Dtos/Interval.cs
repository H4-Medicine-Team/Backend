using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class Interval
    {
        public Interval()
        {
            Dosages = new HashSet<Dosage>();
        }

        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? ConsumptionTime { get; set; }
        public int? DaysId { get; set; }

        public virtual Day Days { get; set; }
        public virtual ICollection<Dosage> Dosages { get; set; }
    }
}
