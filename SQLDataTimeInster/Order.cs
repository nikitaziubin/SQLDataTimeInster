using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class Order
{
    public int Id { get; set; }

    public int PaymentId { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<FacilityReservation> FacilityReservations { get; set; } = new List<FacilityReservation>();

    public virtual Payment Payment { get; set; } = null!;
}
