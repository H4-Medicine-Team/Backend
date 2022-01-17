namespace MedicineApi.Models
{
    public class Dosage
    {
        /// <summary>
        /// Unique id for the dosage
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The amount of pills/medicine.
        /// </summary>
        public int Amount{ get; set; }

        /// <summary>
        /// Which unit of measurement the amount is refering to.
        /// </summary>
        public AmountType AmountType{ get; set; }

        /// <summary>
        /// Interval between consumption times.
        /// </summary>
        public Interval Interval { get; set; }

        public Dosage(int amount, AmountType amountType, Interval interval)
        {
            Amount = amount;
            AmountType = amountType;
            Interval = interval;
        }

        public Dosage()
        {
        }
    }
}
