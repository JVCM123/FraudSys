using Amazon.DynamoDBv2;
using FraudSys.Core.Notifications;
using System.Runtime.CompilerServices;

namespace FraudSys.MVC.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Notifier>();
            services.AddSingleton<IAmazonDynamoDB>();

            return services;
        }
    }
}
