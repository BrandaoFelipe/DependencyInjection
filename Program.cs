using Contracts.Entities;
using Contracts.Services;
using System.Globalization;
using System.Text.Json.Serialization;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter contract data");        
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("With date will you use?");
        Console.Write("For today's date press 't' for future date press 'f': ");
        char chooseDate = char.Parse(Console.ReadLine());
        DateTime date;
        if (chooseDate == 't' || chooseDate == 'T')
        {
            date = DateTime.Now;
            Console.WriteLine(date.ToString("dd/MM/yyyy"));
        }
        else
        {
            Console.Write("Date: ");
            date = DateTime.Parse(Console.ReadLine());
        }              
        
        Console.Write("Contract value: ");
        double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Number of installments: ");
        int installments = int.Parse(Console.ReadLine());

        Contract contract = new(number, date);
        PaymentService paymentService = new(contract, value, installments, new PayPal());
        paymentService.PaymentProcessing(contract);

        Console.Clear();

        Console.WriteLine("Installments:");                
        Console.WriteLine(contract);
    }
}