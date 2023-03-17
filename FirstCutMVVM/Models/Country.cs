using System;
using System.Collections.Generic;

namespace FirstCutMVVM.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
