using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public int Capacity { get; set; }

    public int Credits { get; set; }

    public virtual ICollection<Parallel> Parallels { get; set; } = new List<Parallel>();
}
