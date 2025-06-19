using GestionAcademica.API.Domain.Entities;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IFileRepository
{
    void Add(FileEntity file);
    
    void SaveChanges();
}