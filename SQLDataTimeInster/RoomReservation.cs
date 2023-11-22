using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class RoomReservation
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public int GuestId { get; set; }

    public int PaymentId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public virtual Guest Guest { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
