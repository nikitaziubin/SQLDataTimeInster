using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class RoomType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<SeasonPrice> SeasonPrices { get; set; } = new List<SeasonPrice>();
}
