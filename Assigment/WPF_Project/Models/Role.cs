using System;
using System.Collections.Generic;

namespace WPF_Project.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}
