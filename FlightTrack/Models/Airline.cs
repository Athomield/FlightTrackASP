namespace FlightTrack.Models;

public class Airline
{
    public int AirlineId { get; set; }
    public string Name { get; set; }
    public string IataCode { get; set; } // 2-letter code (e.g., "AA" for American Airlines)
    public string LogoUrl { get; set; }

    // Navigation property
    public ICollection<Flight> Flights { get; set; }
}