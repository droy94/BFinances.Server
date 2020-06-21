using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Request
{
    public class PkwiuRequest
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
