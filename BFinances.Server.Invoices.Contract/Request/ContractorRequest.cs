using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Request
{
    public class ContractorRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Nip { get; set; }
    }
}
