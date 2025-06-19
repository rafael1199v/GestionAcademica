using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface IApplicantRepository
    {
        Applicant GetById(int id);
        int GetIdByUserId(int userId);
    }
}