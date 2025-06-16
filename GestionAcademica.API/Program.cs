using System.Security.Claims;
using GestionAcademica.API;
using GestionAcademica.API.Application.Interfaces.Mappers;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Application.Mappers;
using GestionAcademica.API.Application.UseCases;
using GestionAcademica.API.Application.Utilities;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GestionAcademicaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddScoped<IHrRepository, HrRepository>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IVacancyRepository, VacancyRepository>();

builder.Services.AddScoped<IHashUtility, HashUtility>();

builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
builder.Services.AddScoped<IProfessorMapper, ProfessorMapper>();
builder.Services.AddScoped<IDetailSubjectUseCase, DetailSubjectUseCase>();
builder.Services.AddScoped<ICreateSubjectUseCase, CreateSubjectUseCase>();
builder.Services.AddScoped<IProfessorManagementUseCase, ProfessorManagementUseCase>();
builder.Services.AddScoped<ICreateVacancyUseCase, CreateVacancyUseCase>();

builder.Services.AddScoped<IManageVacancies, ManageVacancies>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
