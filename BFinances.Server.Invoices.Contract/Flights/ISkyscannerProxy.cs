using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Countries;

namespace BFinances.Server.Invoices.Contract.Flights
{
    public interface ISkyscannerProxy
    {
        Task<AvailableCountriesResponse> GetAvailableCountries();
    }
}
