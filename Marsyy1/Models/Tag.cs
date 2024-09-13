using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string ColorP => "#" + Color;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
