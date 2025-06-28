using Amazon.DynamoDBv2;
using FraudSys.Core.Notifications;
using FraudSys.DataAccess.Repositories;
using FraudSys.Domain.Interfaces;
using FraudSys.Domain.Services;

namespace FraudSys.MVC.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Notifier>(); 

            services.AddScoped<IContaCorrenteLimiteRepository, ContaCorrenteLimiteRepository>();
            services.AddScoped<IContaCorrenteLimiteService, ContaCorrenteLimiteService>();

            return services;
        }
    }
}
