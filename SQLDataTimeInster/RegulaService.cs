using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class RegulaService
{
    public int Id { get; set; }

    public DateOnly IntervalDays { get; set; }

    public virtual ICollection<RoomServicesCatalog> RoomServicesCatalogs { get; set; } = new List<RoomServicesCatalog>();
}
