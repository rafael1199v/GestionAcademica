using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistance.Context;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{

    private readonly GestionAcademicaContext _context;

    public UserRepository(GestionAcademicaContext context)
    {
        _context = context;
    }

    public User GetById(int id)
    {
        User? user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
            throw new Exception("No se encontro el usuario");

        return user;
    }

    public User? GetByInstitutionalEmail(string institutionalEmail)
    {
        return _context.Users.FirstOrDefault(user => user.InstitutionalEmail == institutionalEmail);
    }
    public User? GetByEmail(string Email)
    {
        return _context.Users.FirstOrDefault(user => user.PersonalEmail == Email);
    }
    public Applicant Add(Applicant user)
    {
        _context.Applicants.Add(user);
        _context.SaveChanges();

        return user;
    }
}