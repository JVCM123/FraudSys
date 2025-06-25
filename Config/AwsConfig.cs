using FraudSys.Core.Config;

namespace FraudSys.MVC.Config
{
    public static class AwsConfig
    {
        public static WebApplicationBuilder ConfigureAWS(this WebApplicationBuilder builder)
        {
            var awsOptions = builder.Configuration.GetAWSOptions();
            builder.Services.AddDefaultAWSOptions(awsOptions);

            var dynamoConfig = builder.Configuration.GetSection("DynamoTables");
            builder.Services.Configure<DbSettings>(dynamoConfig);

            return builder;
        }
    }
}
