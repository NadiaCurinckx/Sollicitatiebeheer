using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Model.Vacatures;

namespace Sollicitatiebeheer.Data.EFCore.MigrationsHelpApp {
    class Program {
        static void Main(string[] args) {
            if (args == null || args.Length == 0)
                return;

            if (args[0].Equals("drop")) {
                using (var db = MaakContext()) {
                    db.Database.EnsureDeleted();
                }
            }

            if (args[0].Equals("seed")) {
                Console.WriteLine("Seeding...");

                using (var db = MaakContext()) {
                    if (!db.Vacatures.Any()) {
                        MaakVacatures(db);
                    }
                }

                Console.WriteLine("Seeding done.");
            }
        }

        private static void MaakVacatures(SollicitatiebeheerContext db) {
            Console.WriteLine("Vacatures maken...");
            db.Vacatures.AddRange(
                new VacatureBuilder().MetVacaturenummer("56063108").MetAfdeling("OOOC Potgieter").MetFunctie("Crisisbegeleider").MetOmschrijving("ipv Thalissa Tilemans").Build(),
                new VacatureBuilder().MetVacaturenummer("56112374").MetAfdeling("OOOC Jacob Jordaens").MetFunctie("Begeleider").MetOmschrijving("ipv Ellen De Maere").Build(),
                new VacatureBuilder().MetVacaturenummer("56135852").MetAfdeling("Technische dienst").MetFunctie("Onderhoudsmedewerker").MetOmschrijving("verv Klaus").Build()
            );
            db.SaveChanges();
            Console.WriteLine("Vacatures aangemaakt.");
        }

        private static SollicitatiebeheerContext MaakContext() {
            var connectionString =
                Environment.GetEnvironmentVariable("SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer");
            var dbContextOptions = new DbContextOptionsBuilder<SollicitatiebeheerContext>();
            dbContextOptions.UseSqlServer(connectionString);
            var options = dbContextOptions.Options;
            return new SollicitatiebeheerContext(options);
        }
    }
}