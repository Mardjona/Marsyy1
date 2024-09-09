using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Gender
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
