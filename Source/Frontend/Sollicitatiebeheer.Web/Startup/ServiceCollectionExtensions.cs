using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace Sollicitatiebeheer.Web.Startup {
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/> to make Startup.cs readible.
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// Adds Autofac as DI container, configures it and returns the IServiceProvider.
        /// </summary>        
        public static IServiceProvider AddAndConfigureAutofac(this IServiceCollection serviceCollection) {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            return serviceProvider;
        }

        /// <summary>
        /// Adds MediatR and scans all referenced assemblies for types used.
        /// </summary>        
        public static void AddAndConfigureMediatR(this IServiceCollection serviceCollection) {
            serviceCollection.AddMediatR(GetReferencedAssemblies());
        }

        private static Assembly[] GetReferencedAssemblies() {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;

            foreach (var library in dependencies) {
                if (IsCandidateCompilationLibrary(library)) {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }

            assemblies.Add(typeof(Startup).GetTypeInfo().Assembly);

            return assemblies.ToArray();
        }

        private static bool IsCandidateCompilationLibrary(RuntimeLibrary library) {
            return library.Name == nameof(Sollicitatiebeheer)
                   || library.Dependencies.Any(d => d.Name.StartsWith(nameof(Sollicitatiebeheer)));
        }
    }
}
