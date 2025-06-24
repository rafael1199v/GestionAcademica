using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface IApplicantRepository
    {
        int GetIdByUserId(int userId);
        // public Applicant Add(Applicant user);
        public void Add(ApplicantEntity applicantEntity);
    }
}