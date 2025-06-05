using System.Security.Claims;
using GestionAcademica.API;
using GestionAcademica.API.Application;
using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Infraestructure.Repository;
using GestionAcademica.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.Authority = domain;
//         options.Audience = builder.Configuration["Auth0:Audience"];
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             NameClaimType = ClaimTypes.NameIdentifier
//         };
//     });
//
//
// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy(
//         "read:messages",
//         policy => policy.Requirements.Add(
//             new HasScopeRequirement("read:messages", domain)
//         )
//     );
//     
//     options.AddPolicy(
//         "read:professors",
//         policy => policy.Requirements.Add(
//             new HasScopeRequirement("read:professors", domain)));
//     
//     options.AddPolicy(
//             "create:professors",
//             policy => policy.Requirements.Add(
//                 new HasScopeRequirement("create:professors", domain))
//         );
//     
//     options.AddPolicy(
//         "delete:professors",
//         policy => policy.Requirements.Add(
//             new HasScopeRequirement("delete:professors", domain))
//         );
//     
//     options.AddPolicy(
//         "update:professors",
//         policy => policy.Requirements.Add(
//             new HasScopeRequirement("update:professors", domain))
//         );
// });
//
// builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
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

builder.Services.AddScoped<IRegisterProfessorUseCase, RegisterProfessorUseCase>();
builder.Services.AddScoped<IDetailProfessorUseCase, DetailProfessorUseCase>(); 
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHashUseCase, HashUseCase>();
builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
builder.Services.AddScoped<IGetProfessorInformation, GetProfessorInformation>();
builder.Services.AddScoped<IDetailSubjectUseCase, DetailSubjectUseCase>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

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
