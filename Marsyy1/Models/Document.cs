using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Document
{
    public int Id { get; set; }

    public int Documentpath { get; set; }

    public virtual ICollection<Documentofclient> Documentofclients { get; set; } = new List<Documentofclient>();
}
