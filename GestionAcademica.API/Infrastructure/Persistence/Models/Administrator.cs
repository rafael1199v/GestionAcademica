using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Infrastructure.Persistence.Models;

public partial class Administrator
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Career> Careers { get; set; } = new List<Career>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
