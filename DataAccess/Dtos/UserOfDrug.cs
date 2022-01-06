using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class UserOfDrug
    {
        public int Id { get; set; }
        public int? Did { get; set; }
        public int? Uid { get; set; }

        public virtual Drug DidNavigation { get; set; }
        public virtual User UidNavigation { get; set; }
    }
}
