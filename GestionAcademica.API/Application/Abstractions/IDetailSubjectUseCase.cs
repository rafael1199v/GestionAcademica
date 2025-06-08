using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions
{
    public interface IDetailSubjectUseCase
    {
        List<SubjectDTO> ObtainAllSubjects();
        SubjectDTO ObtainSubjectById(int id);
        void UpdateSubject(SubjectDTO subject);
    }
}
