using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class OrderTrip
{
    public string OrderId { get; set; } = null!;

    public string? CustomerId { get; set; }

    public string? QuotationId { get; set; }

    public string? PaymentStatus { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? TripId { get; set; }

    public int? Quantity { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Quotation? Quotation { get; set; }

    public virtual Trip? Trip { get; set; }
}
