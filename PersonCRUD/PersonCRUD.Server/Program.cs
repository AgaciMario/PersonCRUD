using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PersonCRUD.Application.Commands.CreatePersonCommand;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Services;
using PersonCRUD.Infra.Context;
using PersonCRUD.Infra.Repository;
using PersonCRUD.Infra.Seed;
using PersonCRUD.Server.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreatePersonHandler).Assembly));

builder.Services.AddControllers().AddJsonOptions((options) =>
{
    options.AllowInputFormatterExceptionMessages = false;
});

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
            Name = "Agaci Mário",
            Email = "agaci.nobre@gmail.com",
            Url = new Uri("http://www.linkedin.com/in/agaci-m%C3%A1rio-a782931ab")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/license/mit")
        }
    });

    // Gerando xml de documentação a partir dos comentários no código (XML Comments)
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

// Resolvendo dependências da aplicação
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();


builder.Services.AddDbContext<PersonDbContext>(options => options.UseInMemoryDatabase("Person"));

var app = builder.Build();

app.UseCors("AllowLocalhost5173");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PersonDbContext>();
    DbSeed.Initialize(db);
}

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
