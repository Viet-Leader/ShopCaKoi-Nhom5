﻿using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Koi
{
    public string KoiId { get; set; } = null!;

    public string? Species { get; set; }

    public decimal? Size { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<KoiFarm> KoiFarms { get; set; } = new List<KoiFarm>();
}
