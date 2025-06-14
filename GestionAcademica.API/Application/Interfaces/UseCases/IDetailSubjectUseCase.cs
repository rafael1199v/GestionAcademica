using GestionAcademica.API.Application.DTOs;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface IDetailSubjectUseCase
    {
        List<SubjectDTO> ObtainAllSubjects();
        SubjectDTO ObtainSubjectById(int id);
        void UpdateSubject(SubjectDTO subject);
    }
}
