using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Dashboard.Contract.Response;
using BFinances.Server.Dashboard.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace BFinances.Server.Dashboard.Application.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public Task<DashboardResponse> Get()
        {
            return _dashboardService.Get();
        }
    }
}