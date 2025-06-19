using GestionAcademica.API.Domain.Exceptions;

namespace GestionAcademica.API.Domain.Entities;

public class FileEntity
{
    public int Id { get; set; }

    public string Filename { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string? FileDescription { get; set; }

    public string FilePath { get; set; } = null!;
    
    public IFormFile File { get; set; } = null!;
    
    public static FileEntity CreateFile(string fileName, string fileExtension, string? fileDescription, string filePath, IFormFile? file)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new DomainException("El nombre del archivo es requerido");
        
        if(string.IsNullOrWhiteSpace(fileExtension))
            throw new DomainException("El archivo debe contener una extension");
        
        if(string.IsNullOrWhiteSpace(filePath))
            throw new DomainException("El archivo debe contener una ruta donde guardarse");

        if (file is null)
            throw new DomainException("El archivo debe contener informacion");

        return new FileEntity
        {
            Id = 0,
            Filename = fileName,
            FileExtension = fileExtension,
            FilePath = filePath,
            FileDescription = fileDescription,
            File =  file
        };
    }
}