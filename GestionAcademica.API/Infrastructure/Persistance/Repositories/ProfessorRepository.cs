using System.Linq.Expressions;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistance.Context;
using GestionAcademica.API.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistance.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly GestionAcademicaContext _context;

        public ProfessorRepository(GestionAcademicaContext context)
        {
            _context = context;
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

        public List<Professor> GetAllWithDetails()
        {
            
            return _context.Professors.Include(P=>P.User).ToList();
        }

        public Professor GetById(int id)
        {
            Professor? professor = _context.Professors
                .Include(_professor => _professor.User)
                .FirstOrDefault(_professor => _professor.Id == id);

            if (professor == null)
                throw new Exception("Profesor no encontrado");

            return professor;
        }

        public Professor Add(Professor professor)
        {
            _context.Professors.Add(professor);
            _context.SaveChanges();
            
            return professor;
        }

        public void Update(Professor professor)
        {
            _context.Update(professor);
            _context.SaveChanges();
        }
        
        //TODO: Verificar la viabilidad de crear un repositorio mas abstracto
        public IQueryable<Professor> FindByCondition(Expression<Func<Professor, bool>> expression)
        {
            return _context.Professors.Where(expression);
        }
    }
}
