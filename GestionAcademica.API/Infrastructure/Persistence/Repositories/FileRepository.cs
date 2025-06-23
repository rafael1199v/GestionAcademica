using GestionAcademica.API.Application.DTOs.File;
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

    public void AddWithApplication(FileEntity file, int applicationId)
    {
        File newFile = FileMapper.FileEntityToFile(file);
        Models.Application? application = _context.Applications.FirstOrDefault(x => x.Id == applicationId);

        if (application is null)
            throw new Exception("No se encontro la postulacion");
        
        newFile.Applications.Add(application);
        
        _context.Files.Add(newFile);
    }


    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public DownloadFileDTO GetInformationToDownloadById(int fileId)
    {
        File file = _context.Files.FirstOrDefault(x => x.Id == fileId)
        ?? throw new Exception("No se encontro la postulacion");

        return FileMapper.FileToDownloadDTO(file);
    }
}