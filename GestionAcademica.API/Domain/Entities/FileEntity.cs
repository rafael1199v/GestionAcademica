namespace GestionAcademica.API.Domain.Entities;

public class FileEntity
{
    public int Id { get; set; }

    public string Filename { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string? FileDescription { get; set; }

    public string FilePath { get; set; } = null!;
}