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
        public string ExternalId { get; set; }

        public virtual ICollection<Dosage> Dosages { get; set; }
    }
}
