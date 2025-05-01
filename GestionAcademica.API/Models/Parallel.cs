using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Parallel
{
    public int Id { get; set; }

    public int ParallelNumber { get; set; }

    public int SubjectId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Subject Subject { get; set; } = null!;
}
