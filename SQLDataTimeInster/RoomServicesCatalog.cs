using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class RoomServicesCatalog
{
    public int Id { get; set; }

    public int RegulaServicesId { get; set; }

    public string Type { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public virtual RegulaService RegulaServices { get; set; } = null!;

    public virtual ICollection<RoomService> RoomServices { get; set; } = new List<RoomService>();
}
