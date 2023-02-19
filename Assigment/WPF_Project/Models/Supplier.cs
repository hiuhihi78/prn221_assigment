using System;
using System.Collections.Generic;

namespace WPF_Project.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Import> Imports { get; } = new List<Import>();
}
