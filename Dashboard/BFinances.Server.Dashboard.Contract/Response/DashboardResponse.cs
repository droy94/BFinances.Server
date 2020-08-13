using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Dashboard.Contract.Response
{
    public class DashboardResponse
    {
        public decimal GrossIncome { get; set; }

        public decimal PayableVat { get; set; }

        public decimal PayablePit { get; set; }

        public DateTime StartOfSettlingPeriod { get; set; }

        public DateTime EndOfSettlingPeriod { get; set; }

        public DateTime VatSettlementDate { get; set; }

        public DateTime PitSettlementDate { get; set; }
    }
}