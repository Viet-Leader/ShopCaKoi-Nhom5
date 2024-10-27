using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Trip
{
    public string TripId { get; set; } = null!;

    public DateOnly? DepartureDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public string? FarmId { get; set; }

    public string? KoiId { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual KoiFarm? Farm { get; set; }

    public virtual Koi? Koi { get; set; }

    public virtual ICollection<OrderTrip> OrderTrips { get; set; } = new List<OrderTrip>();
}
