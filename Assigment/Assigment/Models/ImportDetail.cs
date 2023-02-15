using System;
using System.Collections.Generic;

namespace Assigment.Models;

public partial class ImportDetail
{
    public int Quantity { get; set; }

    public double PriceImport { get; set; }

    public int ImportId { get; set; }

    public int ProductId { get; set; }

    public virtual Import Import { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
