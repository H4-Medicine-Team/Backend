using MedicineApi.Models.MedicineDk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineApi.Interfaces;

namespace MedicineApi.Managers
{
    public interface IMedicineDkManager : IGetMedication<GetResult>, ISearchMedication<SearchResult>
    {

    }
}
