using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Domain.Exceptions;

namespace GestionAcademica.API.Domain.Entities;

public class ApplicantEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }
    
    public UserEntity? User { get; set; }
    
}