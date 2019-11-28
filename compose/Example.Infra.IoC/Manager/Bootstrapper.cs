using Example.Application.Abstractions;
using Example.Application.Implementations;
using Example.Domain.Abstractions.Repositories;
using Example.Domain.Abstractions.Services;
using Example.Domain.Implementations.Services;
using Example.Infra.Repository.Context;
using Example.Infra.Repository.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infra.IoC.Manager
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IClientApplicationService, ClientApplicationService>();
            serviceCollection.AddScoped<IClientDomainService, ClientDomainService>();
            serviceCollection.AddScoped<IClientRepository, ClientRepository>();

            serviceCollection.AddSingleton(sp => new ClientManagementContext(configuration.GetConnectionString("Default")));
        }
    }
}
