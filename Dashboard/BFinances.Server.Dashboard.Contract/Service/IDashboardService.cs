using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Dashboard.Contract.Response;

namespace BFinances.Server.Dashboard.Contract.Service
{
    public interface IDashboardService
    {
        // TODO: Add DateTime filter
        public Task<DashboardResponse> Get();
    }
}