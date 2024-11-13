using GesDette.Core.Repository;
using GesDette.data.repository.impl;
using GesDette.Data.Repository;
using GesDette.Data.Repository.EntityFramework;
using GesDette.Data.Repository.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GesDette.Core.Factory.Impl
{
    public class RepositoryFactoryImpl<T> : IRepositoryFactory<T> where T : class
    {
        private readonly IConfiguration configuration;
        private readonly IServiceProvider serviceProvider;
        private IRepository<T> repository;

        public RepositoryFactoryImpl(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            this.configuration = configuration;
            this.serviceProvider = serviceProvider;
        }

        public IRepository<T> GetRepository()
        {
            var databaseType = configuration["Database"];
            var repositoryType = typeof(T);
            switch (databaseType)
            {
                case "EntityFramework":
                    if (repositoryType == typeof(IClientRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<ClientRepositoryImplEf>();
                    } else if (repositoryType == typeof(IUserRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<UserRepositoryImplEf>();
                    }
                    break;
                case "liste":
                    if (repositoryType == typeof(IClientRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<ClientRepositoryImplList>();
                    } else if (repositoryType == typeof(IUserRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<UserRepositoryImplList>();
                    } else if (repositoryType == typeof(IDetteRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<DetteRepositoryImplList>();
                    } else if (repositoryType == typeof(IPayementRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<PayementRepositoryImplList>();
                    } else if (repositoryType == typeof(IArticleRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<ArticleRepositoryImplList>();
                    } else if (repositoryType == typeof(IDetailRepository))
                    {
                        repository = (IRepository<T>)serviceProvider.GetRequiredService<DetailRepositoryImplList>();
                    }
                    break;
                default:
                    throw new InvalidOperationException("Database type not supported");
            }
            return repository;
        }
    }
}