using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk
{
    public class GetMedicine
    {
        /// <summary>
        /// Html element of medicine page
        /// </summary>
        public string[] HtmlFragment { get; set; }

        /// <summary>
        /// Id of html fragment
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// "true" or "false" if title should be shown 
        /// </summary>
        public string ShowTitle { get; set; }

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
