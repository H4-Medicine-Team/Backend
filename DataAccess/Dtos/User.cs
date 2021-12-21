using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class User
    {
        public User()
        {
            Drugs = new HashSet<Drug>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ExternalId { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; }
    }
}
