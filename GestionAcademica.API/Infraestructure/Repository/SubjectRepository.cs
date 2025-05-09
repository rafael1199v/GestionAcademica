using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

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
            throw new NotImplementedException();
        }

        public Subject GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
