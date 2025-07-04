﻿using GestionAcademica.API.Application.DTOs.Subject;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using GestionAcademica.API.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories
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
                .FirstOrDefault(s => s.Id == id)
                ?? throw new Exception("Asignatura no encontrada");

            return subject;
        }

        public void Update(Subject subject)
        {
            Subject? existingSubject = _context.Subjects
                .FirstOrDefault(s => s.Id == subject.Id)
                ?? throw new Exception("Asignatura no encontrada");

            existingSubject = SubjectMapper.UpdateInfo(existingSubject, subject);

            _context.Entry(existingSubject).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<SubjectWithCareersDTO> GetWithCareers()
        {
            return _context.Subjects
                .Include(s => s.Careers)
                .Select(subject => SubjectMapper.MapToSubjectWithCareersDTO(subject))
                .ToList();
        }
    }
}
