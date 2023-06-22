using ApplicationLayer.ServiceAbstractions;
using Infrastructure.ServiceImplementations;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace PresentationLayer_WPF.Common
{
    public static class ServiceConfigurator
    {
        public static IServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IDatabaseDataAccessService, DatabaseDataAccess>();

            return services.BuildServiceProvider();
        }
    }
}
