using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Career
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? AdministratorId { get; set; }

    public virtual Administrator? Administrator { get; set; }

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
