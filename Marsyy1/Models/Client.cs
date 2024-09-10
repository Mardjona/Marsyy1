using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public DateOnly? Dataofvisits => Visits.Count != 0 ? Visits.Select(x => x.Lastdate).Order().First() : null;

    public DateOnly Birthday { get; set; }

    public int? Countofvisit { get; set; }

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public Bitmap? Image => Photopath !=null? new Bitmap($@"Клиенты/{Photopath}") : null!;
}
   
