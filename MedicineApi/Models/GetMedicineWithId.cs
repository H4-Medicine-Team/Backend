using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk.Dtos
{
    public class GetMedicineWithId
    {
        /// <summary>
        /// The unique id which identifies a drug.
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// list of GetMedicineDTO's
        /// </summary>
        public List<GetMedicineDTO> GetMedicineDTOs { get; set; }
    }
}
