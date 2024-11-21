using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Cart
{
    public string CartId { get; set; } = Guid.NewGuid().ToString()!;

    public string CustomerId { get; set; } = null!;

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Customer Customer { get; set; } = null!;
}
