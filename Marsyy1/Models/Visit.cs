using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Starttime { get; set; } = null!;

    public virtual Client IdNavigation { get; set; } = null!;
}
