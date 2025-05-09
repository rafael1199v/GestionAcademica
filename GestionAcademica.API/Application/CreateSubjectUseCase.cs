using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application
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
