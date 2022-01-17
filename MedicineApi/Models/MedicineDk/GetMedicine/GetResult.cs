using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.MedicineDk
{
    public class GetResult
    {
        /// <summary>
        /// Information about medicine
        /// </summary>
        public GetMedicine[] FormattedTextFieldStructures { get; set; }
    }
}
