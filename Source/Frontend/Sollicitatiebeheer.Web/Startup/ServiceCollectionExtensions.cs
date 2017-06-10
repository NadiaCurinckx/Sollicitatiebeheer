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

            // ref: http://docs.autofac.org/en/latest/register/scanning.html#scanning-for-modules
            containerBuilder.RegisterAssemblyModules(GetReferencedAssemblies());
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


        /// <summary>
        /// Helper method to get <see cref="Assembly"/> types from the current application.
        /// </summary>        
        private static Assembly[] GetReferencedAssemblies() {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;

            foreach (var library in dependencies) {
                if (DoesNameContains(nameof(Sollicitatiebeheer), library)) {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }

            assemblies.Add(typeof(Startup).GetTypeInfo().Assembly);

            return assemblies.ToArray();
        }

        /// <summary>
        /// Helper method to filter on a given expected name.
        /// </summary>
        private static bool DoesNameContains(string expectedName, RuntimeLibrary library) {
            return library.Name == expectedName
                   || library.Dependencies.Any(d => d.Name.StartsWith(expectedName));
        }
    }
}
