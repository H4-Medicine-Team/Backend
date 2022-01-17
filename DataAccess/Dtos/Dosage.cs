using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class Dosage
    {
        public int Id { get; set; }
        public int? Amount { get; set; }
        public string AmountType { get; set; }
        public int? DrugId { get; set; }
        public int? IntervalId { get; set; }
        public int? UserId { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual Interval Interval { get; set; }
        public virtual User User { get; set; }
    }
}
