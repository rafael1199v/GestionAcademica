using GestionAcademica.API.Infrastructure.Persistance.Models;

using ApplicationModel = GestionAcademica.API.Infrastructure.Persistance.Models.Application;
// Con esto puedes suprimir líneas largas por la declaración de un objeto Application

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IApplicationRepository
{
    void Create(ApplicationModel application);
    ApplicationModel GetById(int id);
    List<ApplicationModel> GetByVacancy(int vacancyId);
    List<ApplicationModel> GetByApplicant(int applicantId);
    List<ApplicationModel> GetByOwner(int adminId);
    List<ApplicationModel> GetByStatus(int statusId);
    void Update(ApplicationModel application);
}