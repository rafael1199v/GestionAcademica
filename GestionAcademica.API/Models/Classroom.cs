﻿using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class Classroom
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
