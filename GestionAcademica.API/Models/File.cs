using System;
using System.Collections.Generic;

namespace GestionAcademica.API;

public partial class File
{
    public int Id { get; set; }

    public string Filename { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string? FileDescription { get; set; }

    public string FilePath { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
