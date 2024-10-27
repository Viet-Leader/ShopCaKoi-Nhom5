using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public string? AccId { get; set; }

    public string? TripId { get; set; }

    public string? CustomRequest { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public virtual ShopCaKoiAccount? Acc { get; set; }

    public virtual Trip? Trip { get; set; }
}
