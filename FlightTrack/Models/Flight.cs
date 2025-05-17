namespace FlightTrack.Models;

public class Flight
{
    public int FlightId { get; set; }
    public string FlightNumber { get; set; } 
    public DateTime ScheduledDeparture { get; set; }
    public DateTime ScheduledArrival { get; set; }
    public DateTime? ActualDeparture { get; set; }
    public DateTime? ActualArrival { get; set; }
    public string Status { get; set; } 

    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int AirlineId { get; set; }
    
    public Airport DepartureAirport { get; set; }
    public Airport ArrivalAirport { get; set; }
    public Airline Airline { get; set; }
}