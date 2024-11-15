using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class FarmKoi
{
    public string? FarmId { get; set; }

    public string? KoiId { get; set; }

    public virtual KoiFarm? Farm { get; set; }

    public virtual Koi? Koi { get; set; }
}
