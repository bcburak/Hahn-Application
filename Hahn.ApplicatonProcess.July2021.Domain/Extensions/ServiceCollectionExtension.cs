using Hahn.ApplicatonProcess.July2021.Data.Infrastructure;
using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static void AddCommonInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            //serviceCollection.AddScoped<IAssetRepository, AssetRepository>();
            //serviceCollection.AddScoped<IUserRepository, UserRepository>();

            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IAssetService, AssetService>();
        }
    }
   
}
