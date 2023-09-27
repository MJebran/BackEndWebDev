using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Jokecategory
{
    public string Id { get; set; } = null!;

    public string? Categoryname { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Categorizedjoke> Categorizedjokes { get; set; } = new List<Categorizedjoke>();
}
