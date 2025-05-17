namespace FlightTrack.Models;

public class Airport
{
    public int AirportId { get; set; }
    public string Name { get; set; }
    public string IataCode { get; set; }
    public string IcaoCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public ICollection<Flight> DepartingFlights { get; set; }
    public ICollection<Flight> ArrivingFlights { get; set; }
}