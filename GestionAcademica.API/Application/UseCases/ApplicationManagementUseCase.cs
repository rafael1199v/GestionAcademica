using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Persistance.Models;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistance.Models.Application;

namespace GestionAcademica.API.Application.UseCases
{
    public class ApplicationManagementUseCase : IApplicationManagementUseCase
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationManagementUseCase(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public void CreateApplication(ApplicationModel application)
        {
            _applicationRepository.Create(application);
        }

        public ApplicationModel GetApplicationById(int id)
        {
            return _applicationRepository.GetById(id);
        }

        public List<ApplicationModel> GetApplicationsByApplicantId(int applicantId)
        {
            return _applicationRepository.GetByApplicant(applicantId);
        }

        public List<ApplicationModel> GetApplicationsByOwnerId(int adminId)
        {
            return _applicationRepository.GetByOwner(adminId);
        }

        public List<ApplicationModel> GetApplicationsByStatusId(int statusId)
        {
            return _applicationRepository.GetByStatus(statusId);
        }

        public List<ApplicationModel> GetApplicationsByVacancyId(int vacancyId)
        {
            return _applicationRepository.GetByVacancy(vacancyId);
        }

        public void UpdateApplication(ApplicationModel application)
        {
            try {
                _applicationRepository.Update(application);
            }
            catch (Exception ex){
                throw new Exception("Error al actualizar la solicitud: " + ex.Message);
            }
        }
    }
}