using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Infrastructure.Persistence.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Initial { get; set; }

    public string Description { get; set; } = null!;

    public int Credits { get; set; }

    public int? ProfessorId { get; set; }

    public virtual Professor? Professor { get; set; }

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

    public virtual ICollection<Career> Careers { get; set; } = new List<Career>();
}
