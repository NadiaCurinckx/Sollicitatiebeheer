using Microsoft.AspNetCore.Builder;

namespace Sollicitatiebeheer.Web.Startup {
    /// <summary>
    /// Extension methods for <see cref="IApplicationBuilder"/> to make Startup.cs readible.
    /// </summary>
    public static class ApplicationBuilderExtensions {
        /// <summary>
        /// Configures the pipeline to use Mvc with a default routing in place.
        /// </summary>
        /// <param name="applicationBuilder">Pipeline to add configuration to.</param>
        public static IApplicationBuilder UseMvcWithDefaultRoutes(this IApplicationBuilder applicationBuilder) {
            return applicationBuilder.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
