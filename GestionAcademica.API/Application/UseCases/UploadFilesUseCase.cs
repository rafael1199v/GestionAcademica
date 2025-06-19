using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Entities;

namespace GestionAcademica.API.Application.UseCases;

public class UploadFilesUseCase : IUploadFilesUseCase
{
    private readonly string _basePath;
    private readonly IFileRepository _fileRepository;

    public UploadFilesUseCase(IConfiguration configuration, IFileRepository fileRepository)
    {
        _basePath = configuration["UploadSettings:BasePath"] ?? "uploads";
        _fileRepository = fileRepository;
    }
    public void Uploadfiles(List<IFormFile> files, int applicationId)
    {
        
        var fullPathApplication = Path.Combine(_basePath, applicationId.ToString());
        Directory.CreateDirectory(fullPathApplication);
        
        List<FileEntity> fileEntities = files.Select(file =>
        {
            var name = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(fullPathApplication, file.FileName);
            return FileEntity.CreateFile(name, extension, null, fullPath, file);
        }).ToList();

        foreach (var file in fileEntities)
        {
            using (FileStream stream = new FileStream(file.FilePath, FileMode.Create))
            {
                file.File.CopyTo(stream);
            }
            
            _fileRepository.Add(file);
        }
        
        _fileRepository.SaveChanges();
    }
}