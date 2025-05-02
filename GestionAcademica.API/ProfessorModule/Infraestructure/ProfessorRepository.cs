using GestionAcademica.API.Models;
using GestionAcademica.API.ProfessorModule.Domain;
using Microsoft.EntityFrameworkCore.Internal;

namespace GestionAcademica.API.ProfessorModule.Infraestructure
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly GestionAcademicaContext _context;

        public ProfessorRepository(GestionAcademicaContext context)
        {
            _context = context;
        }

        public void Create(Professor professor)
        {
            _context.Professors.Add(professor);
            _context.SaveChanges();
        }

        public void Delete(Professor professor)
        {
            _context.Professors.Remove(professor);
            _context.SaveChanges();
        }

        public List<Professor> GetAll()
        {
            return _context.Professors.ToList();
        }

        public Professor GetById(int id)
        {
            Professor? professor = _context.Professors.FirstOrDefault(_professor => _professor.Id == id);

            if (professor == null)
                throw new Exception("Profesor no encontrado");

            return professor;
        }

        public void Update(Professor professor)
        {
            _context.Update(professor);
            _context.SaveChanges();
        }
    }
}
