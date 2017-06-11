using System;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Sollicitatiebeheer.Data.EFCore {
    public class AutofacConfig : Module {
        protected override void Load(ContainerBuilder builder) {
            var connectionString =
                Environment.GetEnvironmentVariable("SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer");
            var dbContextOptions = new DbContextOptionsBuilder<SollicitatiebeheerContext>();
            dbContextOptions.UseSqlServer(connectionString);
            var options = dbContextOptions.Options;
            builder.Register(c => new SollicitatiebeheerContext(options))
                .InstancePerLifetimeScope().As<ISollicitatiebeheerContext>();
        }
    }
}