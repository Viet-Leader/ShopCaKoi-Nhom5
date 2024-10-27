using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Employee
{
    public string Idnv { get; set; } = null!;

    public string? NameNv { get; set; }

    public string? Role { get; set; }

    public virtual ConsultingStaff? ConsultingStaff { get; set; }

    public virtual DeliveringStaff? DeliveringStaff { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual SalesStaff? SalesStaff { get; set; }
}
