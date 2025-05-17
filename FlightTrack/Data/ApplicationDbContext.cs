using Microsoft.EntityFrameworkCore;
using FlightTrack.Models;

namespace FlightTrack.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Flight> Flights { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Airline> Airlines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId);

            entity.HasOne(f => f.DepartureAirport)
                .WithMany(a => a.DepartingFlights)
                .HasForeignKey(f => f.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(f => f.ArrivalAirport)
                .WithMany(a => a.ArrivingFlights)
                .HasForeignKey(f => f.ArrivalAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(f => f.Airline)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirlineId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportId);
            
            entity.Property(e => e.City).UseCollation("NOCASE");
            entity.Property(e => e.Name).UseCollation("NOCASE");
            entity.Property(e => e.IataCode).UseCollation("NOCASE");
            entity.Property(e => e.IcaoCode).UseCollation("NOCASE");
            entity.Property(e => e.Country).UseCollation("NOCASE");

            entity.HasIndex(e => e.IataCode)
                .IsUnique();
            
            entity.Property(e => e.Latitude).HasPrecision(10, 6);
            entity.Property(e => e.Longitude).HasPrecision(10, 6);
        });

        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.AirlineId);
            entity.HasIndex(e => e.IataCode)
                .IsUnique();
        });
    }
} 