using GesDette.Core.Factory.Impl;
using GesDette.data.repository.impl;
using GesDette.Data.Repository;
using GesDette.Data.Repository.EntityFramework;
using GesDette.Data.Repository.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GesDette.Core.Service
{
    public class RepositoryConfiguration
    {
        public static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var useDatabaseType = configuration["Database"];
            switch (useDatabaseType)
            {
                case "EntityFramework":
                    services.AddTransient<IClientRepository, ClientRepositoryImplEf>();
                    services.AddTransient<IUserRepository, UserRepositoryImplEf>();
                    break;
                case "liste":
                    services.AddTransient<IClientRepository, ClientRepositoryImplList>();
                    services.AddTransient<IUserRepository, UserRepositoryImplList>();
                    services.AddTransient<IDetteRepository, DetteRepositoryImplList>();
                    services.AddTransient<IPayementRepository, PayementRepositoryImplList>();
                    services.AddTransient<IArticleRepository, ArticleRepositoryImplList>();
                    services.AddTransient<IDetailRepository, DetailRepositoryImplList>();
                    break;
                default:
                    break;
            }
            services.AddSingleton<RepositoryFactoryImpl<IClientRepository>>();
            services.AddSingleton<RepositoryFactoryImpl<IUserRepository>>();
            services.AddSingleton<RepositoryFactoryImpl<IDetteRepository>>();
            services.AddSingleton<RepositoryFactoryImpl<IPayementRepository>>();
            services.AddSingleton<RepositoryFactoryImpl<IArticleRepository>>();
            services.AddSingleton<RepositoryFactoryImpl<IDetailRepository>>();
        }
        public static IServiceProvider ConfigureServices()
        {
            // Charger la configuration YAML
            var configuration = new ConfigurationBuilder()
                .LoadYaml(@"C:\Users\assan\OneDrive\Documents\Csarp\gestion_dette\gestion_dette\application.yaml") // Charge le fichier de configuration
                .Build();

            // Créer le container DI
            var services = new ServiceCollection();

            // Configurer les dépôts en fonction du type de base de données
            ConfigureRepositories(services, configuration);

            // Retourner l'instance de ServiceProvider
            return services.BuildServiceProvider();
        }
    }
}
