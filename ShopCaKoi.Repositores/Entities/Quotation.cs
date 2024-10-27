using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Quotation
{
    public string QuotationId { get; set; } = null!;

    public string? OrderId { get; set; }

    public decimal? Amount { get; set; }

    public string? ApproveStatus { get; set; }

    public virtual ICollection<ConsultingStaff> ConsultingStaffs { get; set; } = new List<ConsultingStaff>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<OrderKoi> OrderKois { get; set; } = new List<OrderKoi>();

    public virtual ICollection<OrderTrip> OrderTrips { get; set; } = new List<OrderTrip>();

    public virtual ICollection<SalesStaff> SalesStaffs { get; set; } = new List<SalesStaff>();
}
