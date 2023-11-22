using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class Staff
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public decimal Salary { get; set; }

    public DateOnly HireDate { get; set; }

    public virtual ICollection<RoomService> RoomServices { get; set; } = new List<RoomService>();
}
