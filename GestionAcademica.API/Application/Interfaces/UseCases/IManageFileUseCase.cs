using GestionAcademica.API.Application.DTOs.File;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IManageFileUseCase
{
    DownloadFileDTO DownloadFile(int fileId);

    void DeleteFile(int fileId);
    
}