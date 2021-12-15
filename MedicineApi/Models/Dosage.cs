namespace MedicineApi.Models
{
    public class Dosage
    {
        public int Amount{ get; private set; }
        public AmountType AmountType{ get; private set; }
        public Interval Interval { get; private set; }

        public Dosage(int amount, AmountType amountType, Interval interval)
        {
            Amount = amount;
            AmountType = amountType;
            Interval = interval;
        }
    }
}
