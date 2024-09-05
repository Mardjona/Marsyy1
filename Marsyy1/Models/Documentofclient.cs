using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Documentofclient
{
    public int Id { get; set; }

    public int Clientid { get; set; }

    public int DocumentId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;
}
