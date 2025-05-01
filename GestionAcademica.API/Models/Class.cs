using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Class
{
    public int Id { get; set; }

    public int ProfessorId { get; set; }

    public int ParallelId { get; set; }

    public int ClassroomId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int Day { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Parallel Parallel { get; set; } = null!;

    public virtual Professor Professor { get; set; } = null!;
}
