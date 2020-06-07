using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Countries;
using BFinances.Server.Invoices.Contract.Flights;
using Microsoft.AspNetCore.Mvc;

namespace BFinances.Server.Invoices.Application.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IFlightsService _flightsService;

        public InvoicesController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }

        [HttpGet]
        public Task<AvailableCountriesResponse> GetAvailableCountries()
        {
            return _flightsService.GetAvailableCountries();
        }
    }
}
