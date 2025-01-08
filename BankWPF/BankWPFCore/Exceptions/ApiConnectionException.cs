using System;

namespace BankWPFCore.Exceptions
{
    internal class ApiConnectionException : Exception
    {
        public int ErrorCode { get; set; }

        public string Comment {  get; set; }

        public Exception Exception { get; set; }


        public ApiConnectionException(string message)
        : base(message)
        { }

        public ApiConnectionException(Exception exception, int errorCode, string comment): base() 
        {
            Exception = exception;
            ErrorCode = errorCode;
            Comment = comment;
        }
    }
}
