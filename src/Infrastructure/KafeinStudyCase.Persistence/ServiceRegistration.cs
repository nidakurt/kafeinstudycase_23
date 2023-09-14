using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KafeinStudyCase.Application.Core.Persistence.Repositories.ShippingCompanies;
using KafeinStudyCase.Application.Core.Persistence.UoW;
using KafeinStudyCase.Persistence.Context;
using KafeinStudyCase.Persistence.Repositories.ShippingCompanies;
using KafeinStudyCase.Persistence.UoW;

namespace KafeinStudyCase.Persistence;

public static class ServiceRegistrations
{

    public static void AddPersistenceLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        serviceCollection.AddDbContext<DocumentDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("KafeinStudyCase.DbMigrations")));

        serviceCollection.AddScoped<IDocumentUnitOfWork, DocumentUnitOfWork>();
        serviceCollection.AddScoped<IDocumentRepository, DocumentRepository>();


    }
}