using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class Payment
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public DateOnly PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Result { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<RoomReservation> RoomReservations { get; set; } = new List<RoomReservation>();
}
