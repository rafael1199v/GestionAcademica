using System.Diagnostics;
using GestionAcademica.API.Domain.Exceptions;

namespace GestionAcademica.API.Domain.Entities;

public class VacancyEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int SubjectId { get; set; }

    public int CareerId { get; set; }

    public int AdminId { get; set; }


    public static VacancyEntity CreateVacancy(string name, string description, DateTime startTime, DateTime endTime, int subjectId, int careerId, int adminId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("El nombre es requerido");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("La descripcion es requerida");
        
        if(startTime >= endTime)
            throw new DomainException("La fecha de inicio no puede ser mayor o igual a la de finalizacion");

        if (endTime < DateTime.Now)
            throw new DomainException("La fecha de finalizacion no debe estar en el pasado");

        return new VacancyEntity
        {
            Name = name,
            Description = description,
            StartTime = startTime,
            EndTime = endTime,
            SubjectId = subjectId,
            CareerId = careerId,
            AdminId = adminId
        };
    }
}