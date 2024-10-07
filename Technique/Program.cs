using FunctionalExtensions.ResultExample;

using CSharpFunctionalExtensions;
using System;

namespace FunctionalExtensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var name = CustomerName.Create("ZeroMin");
            var email = Email.Create("zeromin1410@gmail.com");

            var result = Result.Combine(name, email);
            if (result.IsFailure)
            {
                Console.WriteLine("Error");
                
                return;
            }

            var customer = new Customer(name.Value, email.Value);
            var s = customer.Name;
            Console.WriteLine($"{s}");
        }
    }
}
