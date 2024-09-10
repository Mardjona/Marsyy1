using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Document
{
    public int Id { get; set; }

    public string? Documentpath { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
