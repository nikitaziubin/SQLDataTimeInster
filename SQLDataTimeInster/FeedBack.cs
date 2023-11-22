using System;
using System.Collections.Generic;

namespace SQLDataTimeInster;

public partial class FeedBack
{
    public int Id { get; set; }

    public int GuestId { get; set; }

    public string Comments { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Guest Guest { get; set; } = null!;
}
