using System.Linq.Expressions;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

/*
 var professorModel = ToModel(professorEntity);

// Adjuntamos manualmente la entidad al contexto
_context.Professors.Attach(professorModel);

// Decimos que todo el objeto fue modificado
_context.Entry(professorModel).State = EntityState.Modified;

_context.SaveChanges();
 */

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
            var professorsModel = _context.Professors.Include(P=>P.User).ToList();

            var professorsEntity = professorsModel.Select(professor => ToEntity(professor)).ToList();
            
            return professorsEntity;
        }

        public ProfessorEntity GetById(int id)
        {
            Professor? professor = _context.Professors.AsNoTracking()
                .Include(_professor => _professor.User)
                .FirstOrDefault(_professor => _professor.Id == id)
                ?? throw new Exception("Profesor no encontrado");

            ProfessorEntity entity = ToEntity(professor);
            
            return entity;
        }

        public ProfessorEntity Add(ProfessorEntity professor)
        {
            var professorModel = ToModel(professor);
            
            _context.Professors.Add(professorModel);
            _context.SaveChanges();
            
            professor = ToEntity(professorModel);
            
            return professor;
        }

        public void Update(ProfessorEntity professor)
        {
            var professorModel = ToModel(professor);
            
            _context.Professors.Update(professorModel);
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
                UserId = professor.UserId,
                User = new UserEntity
                {
                    Id = professor.User.Id,
                    Name = professor.User.Name,
                    LastName = professor.User.LastName,
                    Address = professor.User.Address,
                    BirthDate = professor.User.BirthDate,
                    Password = professor.User.Password,
                    InstitutionalEmail = professor.User.InstitutionalEmail,
                    PersonalEmail = professor.User.PersonalEmail,
                    PhoneNumber = professor.User.PhoneNumber,
                    RoleId = professor.User.RoleId,
                    Status = professor.User.Status,
                }
            };
        }

        private Professor ToModel(ProfessorEntity professor)
        {
            return new Professor
            {
                Id = professor.Id,
                UserId = professor.User.Id,
                User = new User
                {
                    Id = professor.User.Id,
                    Name = professor.User.Name,
                    LastName = professor.User.LastName,
                    Address = professor.User.Address,
                    BirthDate = professor.User.BirthDate,
                    InstitutionalEmail = professor.User.InstitutionalEmail,
                    PersonalEmail = professor.User.PersonalEmail,
                    Password = professor.User.Password,
                    PhoneNumber = professor.User.PhoneNumber,
                    RoleId = professor.User.RoleId
                }
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
