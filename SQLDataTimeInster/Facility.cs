using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class Facility
{
    public int Id { get; set; }

    public int FacilitiesTypeId { get; set; }

    public int StockKeepingUnitId { get; set; }

    public virtual ICollection<FacilitiesAvailabilityHistory> FacilitiesAvailabilityHistories { get; set; } = new List<FacilitiesAvailabilityHistory>();

    public virtual FacilitiesType FacilitiesType { get; set; } = null!;

    public virtual ICollection<FacilityReservation> FacilityReservations { get; set; } = new List<FacilityReservation>();

    public virtual StockKeepingUnit StockKeepingUnit { get; set; } = null!;
}
