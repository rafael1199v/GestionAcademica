using System;
using System.Collections.Generic;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Models;

public partial class Classroom
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;
}
