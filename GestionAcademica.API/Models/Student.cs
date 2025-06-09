using System;
using System.Collections.Generic;
using GestionAcademica.API.Models;

namespace GestionAcademica.API;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
