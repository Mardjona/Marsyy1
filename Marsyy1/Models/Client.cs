using System;
using System.Collections.Generic;

namespace Marsyy1.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Photopath { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly Dataofvisit { get; set; }

    public DateOnly Birthday { get; set; }

    public int? Countofvisit { get; set; }

    public virtual ICollection<Documentofclient> Documentofclients { get; set; } = new List<Documentofclient>();

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
