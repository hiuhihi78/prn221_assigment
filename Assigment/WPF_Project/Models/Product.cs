using System;
using System.Collections.Generic;

namespace WPF_Project.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public int Discount { get; set; }

    public string Country { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ImportDetail> ImportDetails { get; } = new List<ImportDetail>();

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
