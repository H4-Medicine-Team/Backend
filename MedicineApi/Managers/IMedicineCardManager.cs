using MedicineApi.Models;
using System.Threading.Tasks;

namespace MedicineApi.Managers
{
    public interface IMedicineCardManager
    {
        /// <summary>
        /// Retrieves the medicinecard from the given cpr number.
        /// </summary>
        /// <param name="cprNumber">The unique identifier representing a person.</param>
        /// <returns>A medicinecard with: medicine, dosage, created timestamps.</returns>
        Task<MedicineCard> GetMedicineCardAsync(string cprNumber);
    }
}
