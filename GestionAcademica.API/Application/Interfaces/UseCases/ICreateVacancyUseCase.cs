using GestionAcademica.API.Application.DTOs.Subject;
using GestionAcademica.API.Application.DTOs.Vacancy;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface ICreateVacancyUseCase
{
   void CreateVacancy(CreateVacancyDTO createVacancyDto);
   public List<SubjectWithCareersDTO> GetSubjectsWithCareers();
}