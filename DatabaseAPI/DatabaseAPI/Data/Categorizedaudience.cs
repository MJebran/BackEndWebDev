using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Categorizedaudience
{
    public string Id { get; set; } = null!;

    public string Audienceid { get; set; } = null!;

    public string Audiencecategoryid { get; set; } = null!;

    public virtual Audience Audience { get; set; } = null!;

    public virtual Audiencecategory Audiencecategory { get; set; } = null!;
}
