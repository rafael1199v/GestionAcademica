using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IUserRepository
{
    User GetById(int id);
    User? GetByInstitutionalEmail(string institutionalEmail);
    public User? GetByEmail(string Email);
    Applicant Add(Applicant user);
}