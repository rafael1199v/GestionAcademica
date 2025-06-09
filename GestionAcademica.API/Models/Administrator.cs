using System;
using System.Collections.Generic;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Models;

public partial class Administrator
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Career> Careers { get; set; } = new List<Career>();

    public virtual User User { get; set; } = null!;
}
