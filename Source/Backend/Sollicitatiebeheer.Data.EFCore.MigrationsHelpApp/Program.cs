using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Model.Afdelingen;

namespace Sollicitatiebeheer.Data.EFCore.MigrationsHelpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EFCore Migrations Helper");

            if (args == null || args.Length == 0)
                return;

            if (args[0].Equals("seed"))
            {
                var connectionString =
                    Environment.GetEnvironmentVariable("SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer");
                var dbContextOptions = new DbContextOptionsBuilder<SollicitatiebeheerContext>();
                dbContextOptions.UseSqlServer(connectionString);
                var options = dbContextOptions.Options;
                using (var db = new SollicitatiebeheerContext(options))
                {
                    if (!db.Afdelingen.Any()) { MaakAfdelingen(db); }
                    if (!db.Vacatures.Any()) { MaakVacatures(db); }
                }

                Console.WriteLine("Seeding done.");
            }
        }

        private static void MaakAfdelingen(SollicitatiebeheerContext db)
        {
            Console.WriteLine("Creating afdelingen...");
            db.Afdelingen.AddRange(
                new AfdelingBuilder().MetNaam("Personeelsdienst").Build(),
                new AfdelingBuilder().MetNaam("Boekhouding").Build(),
                new AfdelingBuilder().MetNaam("Administratie").Build(),
                new AfdelingBuilder().MetNaam("Den Dam").Build(),
                new AfdelingBuilder().MetNaam("'t Zuid").Build(),
                new AfdelingBuilder().MetNaam("Conscience").Build(),
                new AfdelingBuilder().MetNaam("Thuisbegeleiding").Build(),
                new AfdelingBuilder().MetNaam("PZW").Build(),
                new AfdelingBuilder().MetNaam("Berkelhoeve").Build(),
                new AfdelingBuilder().MetNaam("Technische Dienst").Build(),
                new AfdelingBuilder().MetNaam("School Pro").Build(),
                new AfdelingBuilder().MetNaam("Tsedek").Build()
            );
            db.SaveChanges();
            Console.WriteLine("Afdelingen created.");
        }

        private static void MaakVacatures(SollicitatiebeheerContext db)
        {
            Console.WriteLine("Creating vacatures...");
            db.Vacatures.AddRange(
                new VacatureBuilder().MetVacaturenummer("56063108").MetAfdeling("OOOC Potgieter").MetFunctie("Crisisbegeleider").MetOmschrijving("ipv Thalissa Tilemans").Build(),
                new VacatureBuilder().MetVacaturenummer("56112374").MetAfdeling("OOOC Jacob Jordaens").MetFunctie("Begeleider").MetOmschrijving("ipv Ellen De Maere").Build(),
                new VacatureBuilder().MetVacaturenummer("56135852").MetAfdeling("Technische dienst").MetFunctie("Onderhoudsmedewerker").MetOmschrijving("verv Klaus").Build()
                            );
            db.SaveChanges();
            Console.WriteLine("Vacatures created.");
        }
    }
}