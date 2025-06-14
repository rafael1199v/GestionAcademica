using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistance.Context;
using GestionAcademica.API.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistance.Repositories
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
            Subject? existingSubject = _context.Subjects
                .FirstOrDefault(s => s.Id == subject.Id);

            if (existingSubject == null)
                throw new Exception("Asignatura no encontrada");

            existingSubject.Name = subject.Name;
            existingSubject.Description = subject.Description;
            existingSubject.Credits = subject.Credits;
            existingSubject.ProfessorId = subject.ProfessorId;

            _context.Entry(existingSubject).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
