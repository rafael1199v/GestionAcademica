using GestionAcademica.API.Models;

namespace GestionAcademica.API.StudentModule.Domain
{
    public interface IStudentRepository
    {
        Student GetById(int id);
        List<Student> GetAll();
        void Create(Student student);
        void Delete(Student student);
        void Update(Student student);
    }
}
