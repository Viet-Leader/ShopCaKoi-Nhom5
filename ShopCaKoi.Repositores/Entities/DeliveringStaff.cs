using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class DeliveringStaff
{
    public string Idnv { get; set; } = null!;

    public string? AssignedDeliveries { get; set; }

    public virtual Employee IdnvNavigation { get; set; } = null!;
}
