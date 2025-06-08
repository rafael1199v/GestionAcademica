using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infraestructure.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly GestionAcademicaContext _context;

        public SubjectRepository(GestionAcademicaContext context)
        {
            _context = context;
        }
        public void Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void Delete(Subject subject)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetById(int id)
        {
            Subject? subject = _context.Subjects
                .FirstOrDefault(s => s.Id == id);

            if (subject == null)
                throw new Exception("Asignatura no encontrada");

            return subject;
        }

        public void Update(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
