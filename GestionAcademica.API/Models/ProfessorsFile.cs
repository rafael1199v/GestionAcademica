using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class ProfessorsFile
{
    public int Id { get; set; }

    public int ProfessorId { get; set; }

    public int FileId { get; set; }

    public virtual File File { get; set; } = null!;

    public virtual Professor Professor { get; set; } = null!;
}
