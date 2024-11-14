using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class KoiFarm
{
    public string FarmId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }

    public string? ContactInfo { get; set; }

    public string KoiId { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual Koi Koi { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
