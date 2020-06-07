using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Countries;

namespace BFinances.Server.Invoices.Contract.Flights
{
    public interface IFlightsService
    {
        Task<List<FlightResponse>> GetCurrentFlights(string countryFrom, string countryTo, DateTime dateFrom,
            DateTime dateTo);

        Task<AvailableCountriesResponse> GetAvailableCountries();
    }
}
