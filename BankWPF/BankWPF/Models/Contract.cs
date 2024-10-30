using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    class Contract
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public string description { get; set; }
        public string product_type_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string contract_amount { get; set; }

    }
}
