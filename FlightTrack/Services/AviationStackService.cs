using System.Text.Json;
using FlightTrack.Models.AviationStack;

namespace FlightTrack.Services;

public class AviationStackService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string BaseUrl = "http://api.aviationstack.com/v1";

    public AviationStackService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["AviationStack:ApiKey"] ?? throw new ArgumentNullException(nameof(configuration), "Aviation Stack API key is not configured");
    }

    public async Task<FlightResponse> GetFlightsByRouteAsync(string depIata, string arrIata, DateTime? date = null)
    {
        var queryParams = new List<string>
        {
            $"access_key={_apiKey}",
            $"dep_iata={depIata}",
            $"arr_iata={arrIata}"
        };

        if (date.HasValue)
        {
            queryParams.Add($"flight_date={date.Value:yyyy-MM-dd}");
        }

        var url = $"{BaseUrl}/flights?{string.Join("&", queryParams)}";
        
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var flightResponse = JsonSerializer.Deserialize<FlightResponse>(content);
        
        return flightResponse ?? throw new Exception("Failed to deserialize Aviation Stack API response");
    }

    public async Task<FlightResponse> GetFlightsByAirlineAsync(string airlineIata, DateTime? date = null)
    {
        var queryParams = new List<string>
        {
            $"access_key={_apiKey}",
            $"airline_iata={airlineIata}"
        };

        if (date.HasValue)
        {
            queryParams.Add($"flight_date={date.Value:yyyy-MM-dd}");
        }

        var url = $"{BaseUrl}/flights?{string.Join("&", queryParams)}";
        
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var flightResponse = JsonSerializer.Deserialize<FlightResponse>(content);
        
        return flightResponse ?? throw new Exception("Failed to deserialize Aviation Stack API response");
    }

    public async Task<FlightResponse> GetFlightByNumberAsync(string flightNumber, DateTime? date = null)
    {
        var queryParams = new List<string>
        {
            $"access_key={_apiKey}",
            $"flight_iata={flightNumber}"
        };

        if (date.HasValue)
        {
            queryParams.Add($"flight_date={date.Value:yyyy-MM-dd}");
        }

        var url = $"{BaseUrl}/flights?{string.Join("&", queryParams)}";
        
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var flightResponse = JsonSerializer.Deserialize<FlightResponse>(content);
        
        return flightResponse ?? throw new Exception("Failed to deserialize Aviation Stack API response");
    }
} 