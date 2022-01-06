using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk.Dtos
{
    public class GetMedicineDTO
    {
        /// <summary>
        /// Html element of medicine page
        /// </summary>
        public string[] HtmlData { get; set; }

        /// <summary>
        /// Id of html fragment
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Special atributes
        /// </summary>
        public SpecialAtribute[] SpecialAttributes { get; set; }

        /// <summary>
        /// Tittle of the html element
        /// </summary>
        public string Title { get; set; }
    }
}
