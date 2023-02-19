using System;
using System.Collections.Generic;

namespace WPF_Project.Models;

public partial class Import
{
    public int Id { get; set; }

    public DateTime ImportDate { get; set; }

    public int StaffId { get; set; }

    public double? TotalAmount { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<ImportDetail> ImportDetails { get; } = new List<ImportDetail>();

    public virtual Staff Staff { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
