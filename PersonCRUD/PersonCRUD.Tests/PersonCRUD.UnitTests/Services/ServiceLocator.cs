using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Infra.Context;
using PersonCRUD.Infra.Repository;
using PersonCRUD.Infra.Seed;

namespace PersonCRUD.UnitTests.Services
{
    public sealed class ServiceLocator
    {
        private static readonly Lazy<ServiceLocator> instance =
            new(() => new ServiceLocator());

        private readonly ServiceProvider serviceProvider;

        private ServiceLocator()
        {
            var services = new ServiceCollection();

            services.AddDbContext<PersonDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "testeDatabase");
            }, ServiceLifetime.Scoped);

            services.AddScoped<IPersonRepository, PersonRepository>();

            serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            DbSeed.Initialize(context);
        }

        public static ServiceLocator Instance => instance.Value;

        public T GetService<T>() where T : notnull
        {
            // TODO: implementar forma melhor de controle do scopo, pois esta implementação mantém
            // referencias a partes de memória que deveriam ser descartadas pelo GC, logo uma seria
            // de problema de segurança, persistencia, e performance iram aparecer com o tempo.
            var scope = serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }
    }
}
