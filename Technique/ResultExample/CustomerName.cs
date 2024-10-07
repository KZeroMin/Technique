using System.Text.RegularExpressions;

using CSharpFunctionalExtensions;

namespace FunctionalExtensions.ResultExample
{
    public class CustomerName
    {
        private readonly string _value;

        public CustomerName(string value)
        {
            _value = value;
        }

        public static Result<CustomerName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<CustomerName>("Name can't be empty");

            if (value.Length > 50)
                return Result.Failure<CustomerName>("Name is too long");

            return Result.Success(new CustomerName(value));
        }
    }

    public class Email
    {
        private readonly string _value;

        public Email(string value)
        { 
            _value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Failure<Email>("E-mail cannot be empty");

            if (email.Length > 50)
                return Result.Failure<Email>("E-mail is too long");

            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                return Result.Failure<Email>("E-mail is invalid");

            return Result.Success(new Email(email));
        }
    }

    public class Customer 
    {
        public CustomerName Name { get; private set; }

        public Email Email { get; private set; }

        public Customer(CustomerName name, Email email)
        {
            Name = name;
            Email = email;
        }
    }
}
