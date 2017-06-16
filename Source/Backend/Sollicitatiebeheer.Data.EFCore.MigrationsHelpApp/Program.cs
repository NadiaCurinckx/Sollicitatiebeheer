using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Model.Afdelingen;
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

                    if (!db.Afdelingen.Any()) {
                        MaakAfdelingen(db.Afdelingen);
                    }

                    if (!db.Vacatures.Any()) {
                        MaakVacatures(db.Vacatures);
                    }

                    ((ISollicitatiebeheerContext)db).SaveChanges();
                }

                Console.WriteLine("Seeding done.");
            }
        }

        private static void MaakAfdelingen(DbSet<Afdeling> db) {
            Console.WriteLine("Afdelingen maken...");
            db.AddRange(
                new AfdelingBuilder().MetNaam("OOOC Potgieter").Build(),
                new AfdelingBuilder().MetNaam("OOOC Jacob Jordaens").Build(),
                new AfdelingBuilder().MetNaam("Technische dienst").Build(),
                new AfdelingBuilder().MetNaam("Personeelsdienst").Build()
            );
            Console.WriteLine("Afdelingen aangemaakt.");
        }

        private static void MaakVacatures(DbSet<Vacature> db) {
            Console.WriteLine("Vacatures maken...");
            db.AddRange(
                new VacatureBuilder().MetVacaturenummer("56063108").MetAfdelingId(1).MetFunctie("Crisisbegeleider").MetOmschrijving("ipv Thalissa Tilemans").Build(),
                new VacatureBuilder().MetVacaturenummer("56112374").MetAfdelingId(2).MetFunctie("Begeleider").MetOmschrijving("ipv Ellen De Maere").Build(),
                new VacatureBuilder().MetVacaturenummer("56135852").MetAfdelingId(3).MetFunctie("Onderhoudsmedewerker").MetOmschrijving("verv Klaus").Build()
            );
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