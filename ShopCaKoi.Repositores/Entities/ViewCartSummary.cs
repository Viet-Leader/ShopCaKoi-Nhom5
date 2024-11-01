using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class ViewCartSummary
{
    public decimal? TotalAmount { get; set; }

    public int? TotalQuantity { get; set; }
}
