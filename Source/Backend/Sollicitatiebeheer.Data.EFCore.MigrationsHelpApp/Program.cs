using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Model.Vacatures;

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

                    if (!db.Vacatures.Any())
                    {
                        CreateVacatures(db);
                    }
                }

                Console.WriteLine("Seeding done.");
            }
        }

        private static void CreateVacatures(SollicitatiebeheerContext db)
        {
            Console.WriteLine("Creating vacatures...");
            db.Vacatures.AddRange(
                new VacatureBuilder().WithVacaturenummer("56063108").WithAfdeling("OOOC Potgieter").WithFunctie("Crisisbegeleider").WithOmschrijving("ipv Thalissa Tilemans").Build(),
                new VacatureBuilder().WithVacaturenummer("56112374").WithAfdeling("OOOC Jacob Jordaens").WithFunctie("Begeleider").WithOmschrijving("ipv Ellen De Maere").Build(),
                new VacatureBuilder().WithVacaturenummer("56135852").WithAfdeling("Technische dienst").WithFunctie("Onderhoudsmedewerker").WithOmschrijving("verv Klaus").Build()
                            );
            db.SaveChanges();
            Console.WriteLine("Vacatures created.");
        }
    }
}