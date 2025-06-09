using System;
using System.Collections.Generic;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
