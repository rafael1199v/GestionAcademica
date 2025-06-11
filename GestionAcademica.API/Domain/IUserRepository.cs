using System.Linq.Expressions;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Domain;

public interface IUserRepository
{
    User GetById(int id);
    User? GetByInstitutionalEmail(string institutionalEmail);
    public User? GetByEmail(string Email);
    User Add(User user);
}