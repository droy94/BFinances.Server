using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BFinances.Server.Invoices.Application.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        public InvoicesController()
        {
        }

        //[HttpGet]
        //public Task<AvailableCountriesResponse> GetAvailableCountries()
        //{
        //    return _flightsService.GetAvailableCountries();
        //}
    }
}
