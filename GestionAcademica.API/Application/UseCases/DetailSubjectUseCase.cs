using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Mappers;
using GestionAcademica.API.Infrastructure.Persistence.Models;

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
                string professorName = GetProfessorName(item.ProfessorId);
                result.Add(SubjectMapper.ModelToDTO(item, professorName));
            }

            return result;
        }
        public SubjectDTO ObtainSubjectById(int id)
        {
            Subject subject = _subjectRepository.GetById(id)
            ?? throw new Exception("Asignatura no encontrada");

            string professorName = GetProfessorName(subject.ProfessorId);

            return SubjectMapper.ModelToDTO(subject, professorName);
        }

        public void UpdateSubject(SubjectDTO subjectDTO)
        {
            Subject subject = _subjectRepository.GetById(subjectDTO.Id)
            ?? throw new Exception("Asignatura no encontrada");

            subject.ProfessorId = subjectDTO.ProfessorId;

            // Siendo una sola línea, no creo que necesite un mapper, al menos no por ahora

            _subjectRepository.Update(subject);
        }
        private string GetProfessorName(int? id)
        {
            if (id != null)
            {
                var professor = _professorManagementUseCase.GetProfessorInformation((int)id);
                return professor.Name + " " + professor.LastName;
            }
            return "";
        }
    }
}
