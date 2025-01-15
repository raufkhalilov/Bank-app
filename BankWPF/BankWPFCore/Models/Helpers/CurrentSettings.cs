using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Models.Helpers
{
    public class CurrentSettings
    {
        public string CurrentApiKey { get; set; }
    }

    public class ApiConfiguration
    {
        public CurrentSettings CurrentSettings { get; set; }

        public ApiConfiguration()
        {
            CurrentSettings = new CurrentSettings();
        }
    }
}
