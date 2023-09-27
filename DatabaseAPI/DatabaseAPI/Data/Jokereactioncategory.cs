using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Jokereactioncategory
{
    public string Id { get; set; } = null!;

    public string? Reactionlevel { get; set; }

    public string? Descriptoin { get; set; }

    public virtual ICollection<Deliveredjoke> Deliveredjokes { get; set; } = new List<Deliveredjoke>();
}
