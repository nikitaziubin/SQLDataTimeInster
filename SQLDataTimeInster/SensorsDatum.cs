using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class SensorsDatum
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public double Temperature { get; set; }

    public double Pressure { get; set; }

    public double Humidity { get; set; }

    public DateTime DateTime { get; set; }

    public virtual Room Room { get; set; } = null!;
}
