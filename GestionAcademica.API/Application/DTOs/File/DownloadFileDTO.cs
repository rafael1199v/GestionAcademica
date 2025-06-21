namespace GestionAcademica.API.Application.DTOs.File;

public class DownloadFileDTO
{
    public byte[]? Bytes { get; set; }
    public string? ContentType { get; set; }
    public required string FileName { get; set; }
    public required string FileExtension { get; set; }
    
    public required string FilePath { get; set; }
}