using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application
{
    public class DetailSubjectUseCase : IDetailSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IGetProfessorInformationUseCase _getProfessorInformationUseCase;
        public DetailSubjectUseCase(ISubjectRepository subjectRepository, IGetProfessorInformationUseCase getProfessorInformationUseCase)
        {
            _subjectRepository = subjectRepository;
            _getProfessorInformationUseCase = getProfessorInformationUseCase;
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
                    ProfessorName = item.ProfessorId.HasValue ? _getProfessorInformationUseCase.GetProfessorInformationRun((int)item.ProfessorId).Name + " " + _getProfessorInformationUseCase.GetProfessorInformationRun((int)item.ProfessorId).LastName : ""
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
                var professor = _getProfessorInformationUseCase.GetProfessorInformationRun((int)subject.ProfessorId);
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
