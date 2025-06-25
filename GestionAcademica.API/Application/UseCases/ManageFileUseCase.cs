using GestionAcademica.API.Application.DTOs.File;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.StaticFiles;

namespace GestionAcademica.API.Application.UseCases;

public class ManageFileUseCase : IManageFileUseCase
{
    
    private readonly IFileRepository _fileRepository;

    public ManageFileUseCase(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public DownloadFileDTO DownloadFile(int fileId)
    {
        DownloadFileDTO file = _fileRepository.GetInformationToDownloadById(fileId);
        
        if(!System.IO.File.Exists(file.FilePath))
            throw new Exception("No se encontro el archivo");

        byte[] fileBytes;

        using (var stream = new StreamReader(file.FilePath))
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.BaseStream.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
        }
        
        var provider = new FileExtensionContentTypeProvider();

        if (!provider.TryGetContentType(file.FilePath, out string contentType))
        {
            contentType = "application/octet-stream";
        }
        
        file.ContentType = contentType;
        file.Bytes = fileBytes;

        return file;
    }
    
}