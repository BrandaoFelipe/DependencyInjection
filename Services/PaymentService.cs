using Contracts.Entities;
using System.Globalization;

namespace Contracts.Services
{
    internal class PaymentService
    {
        public Contract Contract { get; set; }
        public double Value { get; set; }
        public int NumberOfInstallments { get; set; }
        private ITaxPay Tax;
        

        public PaymentService()
        {
        }

        public PaymentService(Contract contract, double value, int numberOfInstallments, ITaxPay tax)
        {
            Contract = contract;
            Value = value;
            NumberOfInstallments = numberOfInstallments;
            Tax = tax;
        }

        public void PaymentProcessing(Contract contract)
        {                       
            
            for (int i = 0; i < NumberOfInstallments; i++)
            {
                DateTime dueDate = contract.Date.AddDays((i + 1) * 30);
                
                double amount = Value / NumberOfInstallments;               
                double tax = Tax.Tax(amount) * (i + 1);
                tax += amount;
                double newTax = Tax.Fee(tax);

                contract.InstallmentsList.Add(new Installments(dueDate, newTax));
            }


        }
    }
}
