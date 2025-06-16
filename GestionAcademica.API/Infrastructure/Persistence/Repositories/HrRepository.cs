using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories;

public class HrRepository : IHrRepository
{
    private readonly GestionAcademicaContext _context;

    public HrRepository(GestionAcademicaContext context)
    {
        _context = context;
    }

    public Hr GetById(int id)
    {
        var hr = _context.Hrs.Include(hr => hr.User).FirstOrDefault(x => x.Id == id)
        ?? throw new Exception("El HR no fue encontrado");
        return hr;
    }

    public Hr GetByUserId(int userId)
    {
        var hr = _context.Hrs.Include(hr => hr.User).FirstOrDefault(x => x.UserId == userId)
        ?? throw new Exception("El HR no fue encontrado");
        return hr;
    }
}