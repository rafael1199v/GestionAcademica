using GestionAcademica.API.DTO;

namespace GestionAcademica.API.Administrator.Application
{
    public interface IRegisterStudentUseCase
    {
        void CreateStudent(StudentDTO studentDTO);
    }
}
