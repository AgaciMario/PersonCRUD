using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonCRUD.Domain.Abstractions;
using PersonCRUD.Domain.Services;
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
            services.AddScoped<IPersonService, PersonService>();

            serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            DbSeed.Initialize(context);
        }

        public static ServiceLocator Instance => instance.Value;

        public IServiceScope CreateScope() => serviceProvider.CreateScope();
    }
}
