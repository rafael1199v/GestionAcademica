using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;
using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Mappers;

public interface IApplicationMapper
{
    public ApplicationModel DtoToApp(ApplicationDTO dto);
    public ApplicationDTO AppToDto(ApplicationModel app);
}