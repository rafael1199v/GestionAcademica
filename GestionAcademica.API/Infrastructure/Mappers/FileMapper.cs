using GestionAcademica.API.Application.DTOs.File;
using GestionAcademica.API.Domain.Entities;
using File = GestionAcademica.API.Infrastructure.Persistence.Models.File;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class FileMapper
{
    public static FileDTO ModelToDTO(File file)
    {
        return new FileDTO
        {
            Id = file.Id,
            Name = file.Filename,
            Description = file.FileDescription,
            Extension = file.FileExtension
        };
    }
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
    public static DownloadFileDTO FileToDownloadDTO(File file)
    {
        return new DownloadFileDTO
        {
            FileExtension = file.FileExtension,
            FileName = file.Filename,
            FilePath = file.FilePath,
        };
    }
}