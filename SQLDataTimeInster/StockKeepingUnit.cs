using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class StockKeepingUnit
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public string? Photo { get; set; }

    public string? Video { get; set; }

    public int Likes { get; set; }

    public int Dislikes { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
