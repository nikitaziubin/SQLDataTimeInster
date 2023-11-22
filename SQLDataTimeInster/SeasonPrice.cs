using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class SeasonPrice
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int? RoomTypeId { get; set; }

    public int? LuxId { get; set; }

    public virtual Lux? Lux { get; set; }

    public virtual RoomType? RoomType { get; set; }
}
