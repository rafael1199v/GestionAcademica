using System;
using System.Collections.Generic;

namespace GestionAcademica.API;

public partial class Professor
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<File> Files { get; set; } = new List<File>();
}
