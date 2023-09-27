using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Joke
{
    public string Id { get; set; } = null!;

    public string? Jokename { get; set; }

    public string? Joketext { get; set; }

    public virtual ICollection<Categorizedjoke> Categorizedjokes { get; set; } = new List<Categorizedjoke>();

    public virtual ICollection<Deliveredjoke> Deliveredjokes { get; set; } = new List<Deliveredjoke>();
}
