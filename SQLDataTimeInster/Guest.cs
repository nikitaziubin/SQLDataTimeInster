using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class Guest
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Phone { get; set; }

    public virtual ICollection<FacilityReservation> FacilityReservations { get; set; } = new List<FacilityReservation>();

    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();

    public virtual ICollection<RoomReservation> RoomReservations { get; set; } = new List<RoomReservation>();
}
