using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class FacilityReservation
{
    public int Id { get; set; }

    public int GuestId { get; set; }

    public int FacilityId { get; set; }

    public int OrderId { get; set; }

    public DateOnly ReservationDate { get; set; }

    public virtual Facility Facility { get; set; } = null!;

    public virtual Guest Guest { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
