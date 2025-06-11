using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Applicant
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual User User { get; set; } = null!;
}
