using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.UseCases
{
    public class CreateSubjectUseCase : ICreateSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;

        public CreateSubjectUseCase(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        void ICreateSubjectUseCase.CreateSubject(Subject subject)
        {
            _subjectRepository.Create(subject);
        }
    }
}
