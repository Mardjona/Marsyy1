using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<Tagofclient> Tagofclients { get; set; } = new List<Tagofclient>();
}
