﻿using CommunityToolkit.Mvvm.DependencyInjection;
using Library.Exceptions;
using Library.Services;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Common
{
    public static class ServiceConfigurator
    {
        private const string s_viewsNameSpace = nameof(Views);
        private const string s_viewModelsNameSpace = nameof(ViewModels);
        private const string s_servicesNameSpace = nameof(Library.Services);

        public static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection();

            Assembly libAssembly = Assembly.Load(nameof(Library));
            Assembly wpfAssembly = Assembly.Load(nameof(WpfUI));

            AddViews(serviceCollection, wpfAssembly);
            AddViewModels(serviceCollection, wpfAssembly);
            AddServices(serviceCollection, libAssembly);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            Ioc.Default.ConfigureServices(serviceProvider);

            return serviceProvider;
        }

        private static void AddServices(ServiceCollection serviceCollection, Assembly libAssembly)
        {
            var implementations = libAssembly.GetTypes()
                .Where(implementation => implementation.Name.EndsWith("Service"))
                .Where(implementation => implementation.FullName!.Contains(s_servicesNameSpace))
                .Where(implementation => !implementation.IsInterface)
                .Where(implementation => implementation.BaseType!.IsGenericType && implementation.BaseType.GetGenericTypeDefinition() == typeof(ServiceBase<>));

            foreach (var implementation in implementations)
            {
                var @interface = implementation.GetInterfaces()
                    .Where(i => i.IsInterface)
                    .Where(i => i.Name == $"I{implementation.Name}")
                    .FirstOrDefault();

                if (@interface is null)
                {
                    throw new ServiceInterfaceNotFoundException($"Interface not found for implementation: {implementation.FullName}", implementation);
                }

                serviceCollection.AddTransient(@interface, implementation);
            }
        }

        private static void AddViewModels(ServiceCollection serviceCollection, Assembly assembly)
        {
            var viewModels = assembly.GetTypes()
                            .Where(t => t.Name.EndsWith("ViewModel"))
                            .Where(t => t.FullName!.Contains(s_viewModelsNameSpace));

            foreach (var viewModel in viewModels)
            {
                serviceCollection.AddSingleton(viewModel);
            }
        }

        private static void AddViews(ServiceCollection serviceCollection, Assembly assembly)
        {
            IEnumerable<Type> views = assembly.GetTypes();

            views = views.Where(t => t.Name.EndsWith("View"));
            views = views.Where(t => t.FullName!.Contains(s_viewsNameSpace));

            foreach (var view in views)
            {
                serviceCollection.AddSingleton(view);
            }
        }
    }
}
