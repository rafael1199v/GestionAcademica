using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions
{
    public interface IRegisterStudentUseCase
    {
        void CreateStudent(StudentDTO studentDTO);
    }
}
