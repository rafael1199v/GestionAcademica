using System.Linq.Expressions;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Domain;

public interface IUserRepository
{
    User GetById(int id);
    User? GetByInstitutionalEmail(string institutionalEmail);
}