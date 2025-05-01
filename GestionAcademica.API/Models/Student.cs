using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
