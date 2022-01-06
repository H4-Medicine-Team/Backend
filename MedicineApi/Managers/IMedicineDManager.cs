using MedicineApi.Models.MedicineDk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineApi.Interfaces;
using MedicineApi.Models.MedicineDk.Dtos;

namespace MedicineApi.Managers
{
    public interface IMedicineDkManager : IGetMedication<List<GetMedicineDTO>>, ISearchMedication<List<SearchMedicineDTO>>
    {
        // Add Scoped does not support a generic interface
    }
}
