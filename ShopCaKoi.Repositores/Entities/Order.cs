using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string CustomerId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
