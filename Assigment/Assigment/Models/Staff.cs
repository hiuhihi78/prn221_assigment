using System;
using System.Collections.Generic;

namespace Assigment.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsManager { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Import> Imports { get; } = new List<Import>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
