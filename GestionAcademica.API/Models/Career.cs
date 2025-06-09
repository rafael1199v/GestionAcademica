using System;
using System.Collections.Generic;

namespace GestionAcademica.API;

public partial class Career
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? AdministratorId { get; set; }

    public virtual Administrator? Administrator { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
