using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Model.Vacatures;

namespace Sollicitatiebeheer.Data.EFCore.MigrationsHelpApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("EFCore Migrations Helper");

            if (args == null || args.Length == 0)
                return;

            if (args[0].Equals("seed")) {
                var connectionString =
                    Environment.GetEnvironmentVariable("SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer");
                var dbContextOptions = new DbContextOptionsBuilder<SollicitatiebeheerContext>();
                dbContextOptions.UseSqlServer(connectionString);
                var options = dbContextOptions.Options;
                using (var db = new SollicitatiebeheerContext(options)) {

                    if (!db.Vacatures.Any()) {
                        CreateVacatures(db);
                    }
                }

                Console.WriteLine("Seeding done.");
            }
        }

        private static void CreateVacatures(SollicitatiebeheerContext db) {
            Console.WriteLine("Creating vacatures...");
            db.Vacatures.AddRange(
                new VacatureBuilder().WithNaam("Vacature 1").Build(),
                new VacatureBuilder().WithNaam("Vacature 2").Build(),
                new VacatureBuilder().WithNaam("Vacature 3").Build()
            );
            db.SaveChanges();
            Console.WriteLine("Vacatures created.");
        }
    }
}