using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application
{
    public class DetailSubjectUseCase : IDetailSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        public DetailSubjectUseCase(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public List<SubjectDTO> ObtainAllSubjects()
        {
            List<Subject> list = _subjectRepository.GetAll();

            List<SubjectDTO> result = new List<SubjectDTO>();

            foreach (var item in list)
            {
                result.Add(new SubjectDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Credits = item.Credits,
                    ProfessorId = 0,
                    ProfessorName = ""
                });
            }

            return result;
        }
        public SubjectDTO ObtainSubjectById(int id)
        {
            Subject subject = _subjectRepository.GetById(id);

            return new SubjectDTO
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                Credits = subject.Credits,
                ProfessorId = 0,
                ProfessorName = ""
            };
        }

        public void UpdateSubject(SubjectDTO subject)
        {
            throw new NotImplementedException();
        }
    }
}
