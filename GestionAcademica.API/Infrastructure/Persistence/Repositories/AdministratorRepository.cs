using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories;

public class AdministratorRepository : IAdministratorRepository
{
    
    private readonly GestionAcademicaContext _context;

    public AdministratorRepository(GestionAcademicaContext context)
    {
        _context = context;
    }
    
    public Administrator GetByUserId(int userId)
    {
        var administrator = _context.Administrators
        .Include(admin => admin.User)
        .FirstOrDefault(x => x.UserId == userId)
        ?? throw new Exception("El administrador no fue encontrado");
        return administrator;
    }
}