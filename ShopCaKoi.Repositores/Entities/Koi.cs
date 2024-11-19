using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Koi
{
    public string KoiId { get; set; } = null!;

    public string? Species { get; set; }

    public decimal? Size { get; set; }

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<KoiFarm> KoiFarms { get; set; } = new List<KoiFarm>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<OrderKoi> OrderKois { get; set; } = new List<OrderKoi>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
