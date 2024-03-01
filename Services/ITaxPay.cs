using System;


namespace Contracts.Services
{
     interface ITaxPay
    {
        public double Tax (double amount);
        public double Fee(double amount);
    }
}
