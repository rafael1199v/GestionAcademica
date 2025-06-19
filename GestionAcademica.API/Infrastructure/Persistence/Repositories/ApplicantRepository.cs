using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories;

public class ApplicantRepository : IApplicantRepository
{
    private readonly GestionAcademicaContext _context;

    public ApplicantRepository(GestionAcademicaContext context)
    {
        _context = context;
    }

    // public Applicant GetById(int id)
    // {
    //     var applicant = _context.Applicants.Include(applicant => applicant.User).FirstOrDefault(x => x.Id == id)
    //         ?? throw new Exception("El solicitante no fue encontrado");
    //     return applicant;
    // }
    public int GetIdByUserId(int userId)
    {
        var applicant = _context.Applicants.Include(applicant => applicant.User).FirstOrDefault(x => x.UserId == userId)
            ?? throw new Exception("El solicitante no fue encontrado");
        return applicant.Id;
    }
}