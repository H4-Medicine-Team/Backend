using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class Dosage
    {
        public Dosage()
        {
            Intervals = new HashSet<Interval>();
        }

        public int Id { get; set; }
        public int? Amount { get; set; }
        public int? AmountTypeId { get; set; }
        public int? DrugId { get; set; }

        public virtual AmountType AmountType { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual ICollection<Interval> Intervals { get; set; }
    }
}
