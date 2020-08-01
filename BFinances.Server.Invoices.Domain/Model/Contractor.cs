using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Common.Domain.Model;

namespace BFinances.Server.Invoices.Domain.Model
{
    public class Contractor : Entity
    {
        public string Name { get; set; }

        public string Nip { get; set; }
    }
}