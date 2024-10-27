using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class ShopCaKoiAccount
{
    public string AccId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string Description { get; set; } = null!;

    public int? Role { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
