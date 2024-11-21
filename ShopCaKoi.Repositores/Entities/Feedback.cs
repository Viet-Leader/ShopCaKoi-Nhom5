using System;
using System.Collections.Generic;

namespace ShopCaKoi.Repositores.Entities;

public partial class Feedback
{
    public string Id { get; set; } = Guid.NewGuid().ToString()!;

    public string? CustomerId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Customer? Customer { get; set; }
}
