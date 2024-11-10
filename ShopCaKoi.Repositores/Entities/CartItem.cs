using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class CartItem
{
    public string CartItemId { get; set; } = null!;

    public string? KoiId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public decimal? Total { get; set; }

    public string? TripId { get; set; }

    public virtual Koi? Koi { get; set; }

    public virtual Trip? Trip { get; set; }
}
