using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class Building
{
    public int Id { get; set; }

    public string Adress { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
