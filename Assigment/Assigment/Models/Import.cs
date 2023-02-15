using System;
using System.Collections.Generic;

namespace Assigment.Models;

public partial class Import
{
    public int Id { get; set; }

    public DateTime ImportDate { get; set; }

    public int StaffId { get; set; }

    public double? TotalAmount { get; set; }

    public virtual ICollection<ImportDetail> ImportDetails { get; } = new List<ImportDetail>();

    public virtual Staff Staff { get; set; } = null!;
}
