using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Common.Domain.Model;

namespace BFinances.Server.Invoices.Domain.Model
{
    public class Pkwiu : Entity
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}