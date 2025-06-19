using GestionAcademica.API.Domain.Entities;
using File = GestionAcademica.API.Infrastructure.Persistence.Models.File;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class FileMapper
{
    public static File FileEntityToFile(FileEntity fileEntity)
    {
        return new File
        {
            Id = fileEntity.Id,
            Filename = fileEntity.Filename,
            FileExtension = fileEntity.FileExtension,
            FileDescription = fileEntity.FileDescription,
            FilePath = fileEntity.FilePath
        };
    }
}