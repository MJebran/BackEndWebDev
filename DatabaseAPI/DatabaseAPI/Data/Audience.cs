using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Audience
{
    public string Id { get; set; } = null!;

    public string? Audiencename { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Categorizedaudience> Categorizedaudiences { get; set; } = new List<Categorizedaudience>();

    public virtual ICollection<Deliveredjoke> Deliveredjokes { get; set; } = new List<Deliveredjoke>();
}
