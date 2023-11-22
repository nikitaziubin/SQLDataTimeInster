using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class Room
{
    public int Id { get; set; }

    public int RoomTypeId { get; set; }

    public int LuxId { get; set; }

    public int BuildingId { get; set; }

    public int RoomNumber { get; set; }

    public decimal Area { get; set; }

    public int MaxPersons { get; set; }

    public int Likes { get; set; }

    public int Dilikes { get; set; }

    public int Flour { get; set; }

    public string? Photo { get; set; }

    public string? Video { get; set; }

    public virtual Building Building { get; set; } = null!;

    public virtual Lux Lux { get; set; } = null!;

    public virtual ICollection<RoomAvailabilityHistory> RoomAvailabilityHistories { get; set; } = new List<RoomAvailabilityHistory>();

    public virtual ICollection<RoomReservation> RoomReservations { get; set; } = new List<RoomReservation>();

    public virtual ICollection<RoomService> RoomServices { get; set; } = new List<RoomService>();

    public virtual RoomType RoomType { get; set; } = null!;

    public virtual ICollection<SensorsDatum> SensorsData { get; set; } = new List<SensorsDatum>();
}
