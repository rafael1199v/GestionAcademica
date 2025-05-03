using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Infraestructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly GestionAcademicaContext _context;

        public StudentRepository(GestionAcademicaContext context)
        {
            _context = context;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            Student? student = _context.Students.FirstOrDefault(_student => _student.Id == id);

            if (student == null)
                throw new Exception("El estudiante no ha sido encontrado");

            return student;
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
