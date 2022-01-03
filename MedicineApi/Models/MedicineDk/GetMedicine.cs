using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk
{
    public class GetMedicine
    {
        public string[] HtmlFragment { get; set; }
        public string Id { get; set; }
        public string ShowTitle { get; set; }
        public SpecialAtribute[] SpecialAttributes { get; set; }
        public string Title { get; set; }
    }
}
