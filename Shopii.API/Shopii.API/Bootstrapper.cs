using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shopii.CrossCutting;
using Shopii.Domain.Commands.v1.Users.CreateUser;
using Shopii.Domain.Interfaces.Repositories.v1;
using Shopii.Infraestructure.Data.Repositories.v1;
using Shopii.Infrastructure.Data.Repositories.v1;

namespace Shopii.API
{
    internal static class Bootstrapper
    {
        internal static void ConfigureApp(WebApplicationBuilder builder)
        {
            builder.Services.Configure<AppSettingsConfigurations>(builder.Configuration.GetSection(nameof(AppSettingsConfigurations)));
            builder.Services.AddTransient(sp => sp.GetRequiredService<IOptions<AppSettingsConfigurations>>().Value);
            var appSettings = builder?.Services?.BuildServiceProvider()?.GetRequiredService<AppSettingsConfigurations>();

            InjectRepository(builder,appSettings);

            builder.Services.AddMediatR(
                new MediatRServiceConfiguration().RegisterServicesFromAssemblyContaining(typeof(CreateUserCommandHandler)));

            builder.Services.AddAutoMapper(opt => opt.AddMaps(typeof(CreateUserCommandProfile).Assembly));
        }

        private static void InjectRepository(WebApplicationBuilder builder, AppSettingsConfigurations appSettings)
        {
            // Configurar a injeção do IMongoClient
            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                return new MongoClient(appSettings.MongoDBSettings.ConnectionString);
            });

            // Registrar o Repository para injeção de dependência
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
        }
    }
}
