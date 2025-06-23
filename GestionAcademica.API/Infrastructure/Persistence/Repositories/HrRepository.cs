using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories;

public class HrRepository : IHrRepository
{
    private readonly GestionAcademicaContext _context;

    public HrRepository(GestionAcademicaContext context)
    {
        _context = context;
    }

    public int GetIdByUserId(int userId)
    {
        var hr = _context.Hrs.Include(hr => hr.User).FirstOrDefault(x => x.UserId == userId)
        ?? throw new Exception("El HR no fue encontrado");
        
        return hr.Id;
    }
}