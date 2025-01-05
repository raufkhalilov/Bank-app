using System;

namespace BankWPFCore.Exceptions
{
    internal class ApiConnectionException : Exception
    {
        public ApiConnectionException(string message)
        : base(message)
        { }
    }
}
