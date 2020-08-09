using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Dashboard.Domain.Model
{
    public class Dashboard
    {
        public decimal GrossIncome { get; set; }

        public decimal NetIncome { get; set; }

        public decimal IncomeCosts { get; set; }

        public decimal Vat { get; set; }

        public decimal PayableVat { get; set; }

        public decimal Pit { get; set; }

        public decimal PayablePit { get; set; }
    }
}