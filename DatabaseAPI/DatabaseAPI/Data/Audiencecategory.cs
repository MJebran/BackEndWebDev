using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Audiencecategory
{
    public string Id { get; set; } = null!;

    public string? Categoryname { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Categorizedaudience> Categorizedaudiences { get; set; } = new List<Categorizedaudience>();
}
