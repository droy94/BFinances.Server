using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Invoices.Common.Model;

namespace BFinances.Server.Invoices.Domain.Model
{
    public class Pkwiu : Entity
    {
        public string Code { get; set; }
        
        public string Name { get; set; }
    }
}
