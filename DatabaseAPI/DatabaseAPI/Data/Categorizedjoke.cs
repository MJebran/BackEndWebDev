using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Categorizedjoke
{
    public string Id { get; set; } = null!;

    public string Jokeid { get; set; } = null!;

    public string Jokecategoryid { get; set; } = null!;

    public virtual Joke Joke { get; set; } = null!;

    public virtual Jokecategory Jokecategory { get; set; } = null!;
}
