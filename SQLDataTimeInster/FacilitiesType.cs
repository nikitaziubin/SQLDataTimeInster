using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class FacilitiesType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
