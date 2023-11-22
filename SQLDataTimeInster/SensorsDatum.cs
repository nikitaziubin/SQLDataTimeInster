using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SQLDataTimeInster;

[PrimaryKey(nameof(RoomId), nameof(DateTime), nameof(Temperature))]
public partial class SensorsDatum
{
	//public int Id { get; set; }
	[Column(Order = 0)]
	public int RoomId { get; set; }
	[Column(Order = 1)]
	public DateTime DateTime { get; set; }
	[Column(Order = 2)]
	public double Temperature { get; set; }

    public double Pressure { get; set; }

    public double Humidity { get; set; }


    public virtual Room Room { get; set; } = null!;
}
