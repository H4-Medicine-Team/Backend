using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk.Dtos
{
    public class GetResultDTO
    {
        public List<GetMedicineDTO> GetMedicineDtos { get; set; }
    }
}
