using GestionAcademica.API.DTO;
using GestionAcademica.API.Models;
using GestionAcademica.API.StudentModule.Domain;

namespace GestionAcademica.API.Administrator.Application
{
    public class RegisterStudentUseCase : IRegisterStudentUseCase
    {
        private readonly IStudentRepository _studentRepository;
        public RegisterStudentUseCase(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(StudentDTO studentDTO)
        {

            User user = new User
            {
                Name = studentDTO.Name,
                MiddleName = studentDTO.MiddleName,
                LastName = studentDTO.LastName,
                Email = studentDTO.Email,
                Password = studentDTO.Password,
                PhoneNumber = studentDTO.PhoneNumber,
                BirthDate = DateOnly.Parse(studentDTO.BirthDate),
                RoleId = studentDTO.RoleId
            };

            Student student = new Student
            {
                User = user,
            };


            _studentRepository.Create(student);
        }

    }
}
