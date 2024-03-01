using Contracts.Services;

namespace Contracts.Services
{
    internal class PayPal : ITaxPay
    {
        public double Tax(double amount)
        {
            return amount * 0.01;
            
        }

        public double Fee(double amount)
        {
            double fee = amount + (amount * 0.02);
            return fee;
        }

    }
}
