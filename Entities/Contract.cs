

using Contracts.Services;
using System.Text;
using System.Globalization;

namespace Contracts.Entities
{
    internal class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public List<Installments> InstallmentsList { get; set; } = [];

        public Contract() { }


        public Contract(int number, DateTime date)
        {
            Number = number;
            Date = date;
        }

               
        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (var item in InstallmentsList)
            {
                sb.AppendLine(item.DueDate.ToString("dd:MM:yyyy") + " - " + item.Amount.ToString("F2", CultureInfo.InvariantCulture));                
            }
            return sb.ToString();
        }


    }
}
