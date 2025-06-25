using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GestionAcademica.Test.ApplicantTest;

public class ApplyForVacancyTest
{
    private readonly IApplyForVacancy _applyForVacancy;
    public ApplyForVacancyTest()
    {
        _applyForVacancy = A.Fake<IApplyForVacancy>();
    }
    [Fact]
    public void Apply_Apply()
    {
        // Arrange
        CreateApplicationDTO input = new()
        {
            VacancyId = 1,
            ApplicantId = 1,
            StatusId = 1,
            Files = []
        };
        A.CallTo(() => _applyForVacancy.Apply(input))
            .DoesNothing();
        // Act
        _applyForVacancy.Apply(input);
        // Assert
        A.CallTo(() => _applyForVacancy.Apply(input))
            .MustHaveHappenedOnceExactly();
    }
}