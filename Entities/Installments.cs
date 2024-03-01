

namespace Contracts.Entities
{
    internal class Installments
    {
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }

        public Installments()
        {
        }

        public Installments(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }
    }
}
