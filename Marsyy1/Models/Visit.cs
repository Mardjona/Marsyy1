using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public DateOnly? Lastdate { get; set; }

    public virtual Client Client { get; set; } = null!;
}
