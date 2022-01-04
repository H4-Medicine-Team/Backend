using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk.Dtos
{
    public class GetMedicineDTO
    {
        public string[] HtmlData { get; set; }
        public string Id { get; set; }
        public SpecialAtribute[] SpecialAttributes { get; set; }
        public string Title { get; set; }
    }
}
