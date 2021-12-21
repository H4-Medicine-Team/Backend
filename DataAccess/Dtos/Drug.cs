using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class Drug
    {
        public Drug()
        {
            Dosages = new HashSet<Dosage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Dosage> Dosages { get; set; }
    }
}
