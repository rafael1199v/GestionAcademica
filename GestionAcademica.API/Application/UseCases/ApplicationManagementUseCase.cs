using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using GestionAcademica.API.Application.Interfaces.Mappers;

namespace GestionAcademica.API.Application.UseCases
{
    public class ApplicationManagementUseCase : IApplicationManagementUseCase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationMapper _applicationMapper;
        public ApplicationManagementUseCase(IApplicationRepository applicationRepository, IApplicationMapper applicationMapper)
        {
            _applicationRepository = applicationRepository;
            _applicationMapper = applicationMapper;
        }

        public void CreateApplication(ApplicationDTO application)
        {
            _applicationRepository.Create(_applicationMapper.DtoToApp(application));
        }

        public ApplicationDTO GetApplicationById(int id)
        {
            return _applicationMapper.AppToDto(_applicationRepository.GetById(id));
        }

        public List<ApplicationDTO> GetApplicationsByApplicantId(int applicantId)
        {
            return _applicationRepository.GetByApplicant(applicantId).ToList()
                .Select(_applicationMapper.AppToDto).ToList();
        }

        public List<ApplicationDTO> GetApplicationsByOwnerId(int adminId)
        {
            return _applicationRepository.GetByOwner(adminId).ToList()
                .Select(_applicationMapper.AppToDto).ToList();
        }

        public List<ApplicationDTO> GetApplicationsByStatusId(int statusId)
        {
            return _applicationRepository.GetByStatus(statusId).ToList()
                .Select(_applicationMapper.AppToDto).ToList();
        }

        public List<ApplicationDTO> GetApplicationsByVacancyId(int vacancyId)
        {
            return _applicationRepository.GetByVacancy(vacancyId).ToList()
                .Select(_applicationMapper.AppToDto).ToList();
        }

        public void UpdateApplication(ApplicationDTO application)
        {
            try
            {
                _applicationRepository.Update(_applicationMapper.DtoToApp(application));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la solicitud: " + ex.Message);
            }
        }
    }
}