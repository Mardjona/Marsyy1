using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
