using System.Linq.Expressions;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using GestionAcademica.API.Infrastructure.Mappers;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly GestionAcademicaContext _context;

        public ProfessorRepository(GestionAcademicaContext context)
        {
            _context = context;
        }
        
        public List<ProfessorEntity> GetAllWithDetails()
        {
            var professorsModel = _context.Professors.Include(P => P.User)
                .ToList();

            var professorsEntity = professorsModel.Select(ProfessorMapper.ModelToEntity)
                .ToList();
            
            return professorsEntity;
        }

        public ProfessorEntity GetById(int id)
        {
            Professor? professor = _context.Professors.AsNoTracking()
                .Include(_professor => _professor.User)
                .FirstOrDefault(_professor => _professor.Id == id)
                ?? throw new Exception("Profesor no encontrado");

            ProfessorEntity entity = ProfessorMapper.ModelToEntity(professor);
            
            return entity;
        }

        public ProfessorEntity Add(ProfessorEntity professor)
        {
            var professorModel = ProfessorMapper.EntityToModel(professor);
            
            _context.Professors.Add(professorModel);
            _context.SaveChanges();
            
            professor = ProfessorMapper.ModelToEntity(professorModel);
            
            return professor;
        }

        public void Update(ProfessorEntity professor)
        {
            Professor professorModel = _context.Professors.Include(professor => professor.User).FirstOrDefault(_professor => _professor.Id == professor.Id)
            ?? throw new Exception("Profesor no encontrado");

            professorModel.User.Name = professor.User.Name;
            professorModel.User.LastName = professor.User.LastName;
            professorModel.User.PersonalEmail = professor.User.PersonalEmail;
            professorModel.User.InstitutionalEmail = professor.User.InstitutionalEmail;
            professorModel.User.Address = professor.User.Address;
            professorModel.User.BirthDate = professor.User.BirthDate;
            professorModel.User.PhoneNumber = professor.User.PhoneNumber;
            
            _context.SaveChanges();
        }
        
        public IQueryable<Professor> FindByCondition(Expression<Func<Professor, bool>> expression)
        {
            return _context.Professors.Where(expression);
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
