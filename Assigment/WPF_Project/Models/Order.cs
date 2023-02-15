using System;
using System.Collections.Generic;

namespace WPF_Project.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerPhone { get; set; }

    public double TotalAmount { get; set; }

    public DateTime? DeliverDate { get; set; }

    public int StaffId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Staff Staff { get; set; } = null!;
}
