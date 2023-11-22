using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class RoomAvailabilityHistory
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public bool IsAvailable { get; set; }

    public DateOnly? WritingDate { get; set; }

    public virtual Room Room { get; set; } = null!;
}
