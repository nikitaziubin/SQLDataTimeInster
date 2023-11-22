using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class RoomService
{
    public int Id { get; set; }

    public int StaffId { get; set; }

    public int RoomId { get; set; }

    public int RoomServicesCatalogId { get; set; }

    public DateOnly ServiceDate { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual RoomServicesCatalog RoomServicesCatalog { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
