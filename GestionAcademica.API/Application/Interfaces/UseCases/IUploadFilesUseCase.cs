namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IUploadFilesUseCase
{
    void Uploadfiles(List<IFormFile> files, int applicationId);
}