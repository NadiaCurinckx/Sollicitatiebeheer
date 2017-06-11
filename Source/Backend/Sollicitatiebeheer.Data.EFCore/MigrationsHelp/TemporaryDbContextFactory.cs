using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Sollicitatiebeheer.Data.EFCore.MigrationsHelp {
    public class TemporaryDbContextFactory : IDbContextFactory<SollicitatiebeheerContext> {
        public SollicitatiebeheerContext Create(DbContextFactoryOptions options) {
            var connectionString = Environment.GetEnvironmentVariable("SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer");
            var builder = new DbContextOptionsBuilder<SollicitatiebeheerContext>()
                .UseSqlServer(connectionString, cfg => {
                    // See info on workaround: http://benjii.me/2017/05/enable-entity-framework-core-migrations-visual-studio-2017/
                    cfg.MigrationsAssembly(typeof(SollicitatiebeheerContext).GetTypeInfo().Assembly.GetName().Name);
                });
            return new SollicitatiebeheerContext(builder.Options);
        }
    }
}
