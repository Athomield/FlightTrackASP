using Microsoft.AspNetCore.Mvc;
using FlightTrack.Services;
using FlightTrack.Models.AviationStack;
using FlightTrack.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FlightTrack.Controllers;

public class FlightSearchController : BaseApiController
{
    private readonly AviationStackService _aviationStackService;
    private readonly ApplicationDbContext _context;

    public FlightSearchController(AviationStackService aviationStackService, ApplicationDbContext context)
    {
        _aviationStackService = aviationStackService;
        _context = context;
    }

    [HttpGet("cities")]
    public async Task<ActionResult<FlightResponse>> SearchByCities(
        [FromQuery] string departureCity,
        [FromQuery] string arrivalCity,
        [FromQuery] DateTime? date = null)
    {
        if (string.IsNullOrWhiteSpace(departureCity) || string.IsNullOrWhiteSpace(arrivalCity))
        {
            return BadRequest("Both departure and arrival cities are required.");
        }

        var departureAirports = await _context.Airports
            .Where(a => EF.Functions.Like(a.City, departureCity))
            .Select(a => a.IataCode)
            .ToListAsync();

        if (!departureAirports.Any())
        {
            return NotFound($"No airports found for departure city: {departureCity}");
        }

        var arrivalAirports = await _context.Airports
            .Where(a => EF.Functions.Like(a.City, arrivalCity))
            .Select(a => a.IataCode)
            .ToListAsync();

        if (!arrivalAirports.Any())
        {
            return NotFound($"No airports found for arrival city: {arrivalCity}");
        }

        var allFlights = new List<FlightResponse>();
        foreach (var depAirport in departureAirports)
        {
            foreach (var arrAirport in arrivalAirports)
            {
                try
                {
                    var flights = await _aviationStackService.GetFlightsByRouteAsync(depAirport, arrAirport, date);
                    if (flights != null && flights.Data.Any())
                    {
                        allFlights.Add(flights);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        if (!allFlights.Any())
        {
            return NotFound($"No flights found between {departureCity} and {arrivalCity}");
        }

        var combinedResponse = new FlightResponse
        {
            Pagination = allFlights.First().Pagination,
            Data = allFlights.SelectMany(f => f.Data).ToList()
        };

        return Ok(combinedResponse);
    }

    [HttpGet("countries")]
    public async Task<ActionResult<FlightResponse>> SearchByCountries(
        [FromQuery] string departureCountry,
        [FromQuery] string arrivalCountry,
        [FromQuery] DateTime? date = null)
    {
        if (string.IsNullOrWhiteSpace(departureCountry) || string.IsNullOrWhiteSpace(arrivalCountry))
        {
            return BadRequest("Both departure and arrival countries are required.");
        }

        var departureAirports = await _context.Airports
            .Where(a => EF.Functions.Like(a.Country, departureCountry))
            .Select(a => a.IataCode)
            .ToListAsync();

        if (!departureAirports.Any())
        {
            return NotFound($"No airports found for departure country: {departureCountry}");
        }

        var arrivalAirports = await _context.Airports
            .Where(a => EF.Functions.Like(a.Country, arrivalCountry))
            .Select(a => a.IataCode)
            .ToListAsync();

        if (!arrivalAirports.Any())
        {
            return NotFound($"No airports found for arrival country: {arrivalCountry}");
        }

        var allFlights = new List<FlightResponse>();
        foreach (var depAirport in departureAirports)
        {
            foreach (var arrAirport in arrivalAirports)
            {
                try
                {
                    var flights = await _aviationStackService.GetFlightsByRouteAsync(depAirport, arrAirport, date);
                    if (flights != null && flights.Data.Any())
                    {
                        allFlights.Add(flights);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        if (!allFlights.Any())
        {
            return NotFound($"No flights found between {departureCountry} and {arrivalCountry}");
        }

        var combinedResponse = new FlightResponse
        {
            Pagination = allFlights.First().Pagination,
            Data = allFlights.SelectMany(f => f.Data).ToList()
        };

        return Ok(combinedResponse);
    }
} 