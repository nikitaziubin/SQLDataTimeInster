using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class FacilitiesAvailabilityHistory
{
    public int Id { get; set; }

    public int FacilitiesId { get; set; }

    public bool IsAvailable { get; set; }

    public DateOnly? WritingDate { get; set; }

    public virtual Facility Facilities { get; set; } = null!;
}
