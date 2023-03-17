using System;
using System.Collections.Generic;

namespace FirstCutMVVM.Models;

public partial class User
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Idcountry { get; set; }

    public virtual Country IdcountryNavigation { get; set; } = null!;
}
