using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Customer
{
    public string CustomerId { get; set; } = Guid.NewGuid().ToString()!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? CustomerPassword { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderKoi> OrderKois { get; set; } = new List<OrderKoi>();

    public virtual ICollection<OrderTrip> OrderTrips { get; set; } = new List<OrderTrip>();
}
