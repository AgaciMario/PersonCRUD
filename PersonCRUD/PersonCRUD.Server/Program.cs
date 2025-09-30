using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PersonCRUD.Application.Commands.CreatePersonCommand;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Services;
using PersonCRUD.Infra.Context;
using PersonCRUD.Infra.Repository;
using PersonCRUD.Server.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreatePersonHandler).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Person API",
        Description = "An ASP.NET Core Web API for managing Person information",
        Contact = new OpenApiContact
        {
            Name = "Agaci M�rio",
            Email = "agaci.nobre@gmail.com",
            Url = new Uri("http://www.linkedin.com/in/agaci-m%C3%A1rio-a782931ab")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/license/mit")
        }
    });

    // Gerando xml de documenta��o a partir dos coment�rios no c�digo (XML Comments)
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Resolvendo depend�ncias da aplica��o
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();


builder.Services.AddDbContext<PersonDbContext>(options => options.UseInMemoryDatabase("Person"));

var app = builder.Build();

app.UseCors("AllowLocalhost5173");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
