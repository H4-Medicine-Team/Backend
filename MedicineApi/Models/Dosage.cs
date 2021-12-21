namespace MedicineApi.Models
{
    public class Dosage
    {
        /// <summary>
        /// The amount of pills/medicine.
        /// </summary>
        public int Amount{ get; private set; }

        /// <summary>
        /// Which unit of measurement the amount is refering to.
        /// </summary>
        public AmountType AmountType{ get; private set; }

        /// <summary>
        /// Interval between consumption times.
        /// </summary>
        public Interval Interval { get; private set; }

        public Dosage(int amount, AmountType amountType, Interval interval)
        {
            Amount = amount;
            AmountType = amountType;
            Interval = interval;
        }
    }
}
