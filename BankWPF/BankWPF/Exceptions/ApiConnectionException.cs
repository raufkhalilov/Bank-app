using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Exceptions
{
    internal class ApiConnectionException : Exception
    {
        public ApiConnectionException(string message)
        : base(message)
        { }
    }
}
