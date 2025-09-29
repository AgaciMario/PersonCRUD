using Microsoft.EntityFrameworkCore;
using PersonCRUD.Application.Commands.CreatePersonCommand;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Services;
using PersonCRUD.Infra.Context;
using PersonCRUD.Infra.Repository;
using PersonCRUD.Server.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreatePersonHandler).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Resolvendo dependências da aplicação
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();


builder.Services.AddDbContext<PersonDbContext>(options => options.UseInMemoryDatabase("Person"));

var app = builder.Build();

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
