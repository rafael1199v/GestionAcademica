using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.UseCases
{
    public class DetailSubjectUseCase : IDetailSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IProfessorManagementUseCase _professorManagementUseCase;
        public DetailSubjectUseCase(ISubjectRepository subjectRepository, IProfessorManagementUseCase professorManagementUseCase)
        {
            _subjectRepository = subjectRepository;
            _professorManagementUseCase = professorManagementUseCase;
        }
        public List<SubjectDTO> ObtainAllSubjects()
        {
            List<Subject> list = _subjectRepository.GetAll();

            List<SubjectDTO> result = [];

            foreach (var item in list)
            {
                result.Add(new SubjectDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Credits = item.Credits,
                    ProfessorId = item.ProfessorId.HasValue ? (int)item.ProfessorId : 0,
                    ProfessorName = item.ProfessorId.HasValue ? _professorManagementUseCase.GetProfessorInformation((int)item.ProfessorId).Name + " " + _professorManagementUseCase.GetProfessorInformation((int)item.ProfessorId).LastName : ""
                });
            }

            return result;
        }
        public SubjectDTO ObtainSubjectById(int id)
        {
            Subject subject = _subjectRepository.GetById(id)
            ?? throw new Exception("Asignatura no encontrada");

            string professorName = "";
            if (subject.ProfessorId.HasValue)
            {
                var professor = _professorManagementUseCase.GetProfessorInformation((int)subject.ProfessorId);
                professorName = professor.Name + " " + professor.LastName;
            }

            return new SubjectDTO
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                Credits = subject.Credits,
                ProfessorId = subject.ProfessorId ?? 0,
                ProfessorName = professorName
            };
        }

        public void UpdateSubject(SubjectDTO subjectDTO)
        {
            Subject subject = _subjectRepository.GetById(subjectDTO.Id)
            ?? throw new Exception("Asignatura no encontrada");
            
            subject.ProfessorId = subjectDTO.ProfessorId;

            _subjectRepository.Update(subject);
        }
    }
}
