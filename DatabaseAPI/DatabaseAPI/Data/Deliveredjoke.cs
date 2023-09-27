using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Deliveredjoke
{
    public string Id { get; set; } = null!;

    public DateOnly Delivereddate { get; set; }

    public string Jokereactionid { get; set; } = null!;

    public string Jokeid { get; set; } = null!;

    public string Audienceid { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Audience Audience { get; set; } = null!;

    public virtual Joke Joke { get; set; } = null!;

    public virtual Jokereactioncategory Jokereaction { get; set; } = null!;
}
