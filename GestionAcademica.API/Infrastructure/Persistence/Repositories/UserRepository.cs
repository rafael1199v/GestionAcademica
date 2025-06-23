using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Mappers;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{

    private readonly GestionAcademicaContext _context;

    public UserRepository(GestionAcademicaContext context)
    {
        _context = context;
    }

    public UserEntity GetById(int id)
    {
        User? user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
            throw new Exception("No se encontro el usuario");
        
        return UserMapper.UserModelToEntity(user);
    }

    public UserEntity? GetByInstitutionalEmail(string institutionalEmail)
    {
        User? userModel = _context.Users.FirstOrDefault(user => user.InstitutionalEmail == institutionalEmail);

        if (userModel is null)
            return null;
        
        return UserMapper.UserModelToEntity(userModel);
    }
    public UserEntity? GetByEmail(string Email)
    {
        User? userModel = _context.Users.FirstOrDefault(user => user.PersonalEmail == Email);

        if (userModel is null)
            return null;
        
        return UserMapper.UserModelToEntity(userModel);
    }
    
    //TODO: Mover esto al repositorio de aplicantes
    public Applicant Add(Applicant user)
    {
        _context.Applicants.Add(user);
        _context.SaveChanges();

        return user;
    }
    
}