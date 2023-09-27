using System;
using System.Collections.Generic;

namespace DatabaseAPI.Data;

public partial class Supply
{
    public string Supnr { get; set; } = null!;

    public string Prodnr { get; set; } = null!;

    /// <summary>
    /// purchase_price in eur
    /// </summary>
    public double? PurchasePrice { get; set; }

    /// <summary>
    /// deliv_period in days
    /// </summary>
    public int? DelivPeriod { get; set; }

    public virtual Product ProdnrNavigation { get; set; } = null!;

    public virtual Supplier SupnrNavigation { get; set; } = null!;
}
