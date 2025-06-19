using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Mappers;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using File = GestionAcademica.API.Infrastructure.Persistence.Models.File;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories;

public class FileRepository : IFileRepository
{
    
    private readonly GestionAcademicaContext _context;

    public FileRepository(GestionAcademicaContext context)
    {
        _context = context;
    }
    
    public void Add(FileEntity file)
    {
        File newFile = FileMapper.FileEntityToFile(file);
        _context.Files.Add(newFile);
    }


    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}