using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Professor
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual User User { get; set; } = null!;
}
