using System.Linq.Expressions;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories
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
                .FirstOrDefault(_professor => _professor.Id == id)
                ?? throw new Exception("Profesor no encontrado");
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

        private ProfessorEntity ToEntity(Professor professor)
        {
            return new ProfessorEntity
            {
                Id = professor.Id,
                UserId = professor.User.Id
            };
        }

        private Professor ToModel(ProfessorEntity professor)
        {
            return new Professor
            {
                Id = professor.Id,
                UserId = professor.UserId
            };
        }

        public int GetIdByUserId(int userId)
        {
            Professor? professor = _context.Professors
                .Include(_professor => _professor.User)
                .FirstOrDefault(_professor => _professor.UserId == userId)
                ?? throw new Exception("Profesor no encontrado");
            
            return professor.Id;
        }
    }
}
