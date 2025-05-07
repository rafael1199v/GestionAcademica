using System;
using System.Collections.Generic;

namespace GestionAcademica.API.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PersonalEmail { get; set; } = null!;

    public string InstitutionalEmail { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly BirthDate { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Hr> Hrs { get; set; } = new List<Hr>();

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
