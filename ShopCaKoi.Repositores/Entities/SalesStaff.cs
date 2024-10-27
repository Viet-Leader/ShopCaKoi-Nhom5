using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class SalesStaff
{
    public string Idnv { get; set; } = null!;

    public string? AssignedOrders { get; set; }

    public string? QuotationId { get; set; }

    public virtual Employee IdnvNavigation { get; set; } = null!;

    public virtual Quotation? Quotation { get; set; }
}
