using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class OrderKoi
{
    public string OrderId { get; set; } = null!;

    public string? CustomerId { get; set; }

    public string? QuotationId { get; set; }

    public string? PaymentStatus { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? KoiId { get; set; }

    public int? Quantity { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Koi? Koi { get; set; }

    public virtual Quotation? Quotation { get; set; }
}
