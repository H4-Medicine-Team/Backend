using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class Interval
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public byte[] ConsumptionTime { get; set; }
        public int? DaysId { get; set; }
        public int? DosageId { get; set; }

        public virtual Day Days { get; set; }
        public virtual Dosage Dosage { get; set; }
    }
}
