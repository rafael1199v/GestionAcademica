using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application
{
    public class RegisterStudentUseCase : IRegisterStudentUseCase
    {
        private readonly IStudentRepository _studentRepository;
        public RegisterStudentUseCase(IStudentRepository studentRepository)
        {
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
