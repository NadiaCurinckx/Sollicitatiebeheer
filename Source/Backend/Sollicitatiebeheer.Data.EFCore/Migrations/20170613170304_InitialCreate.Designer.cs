using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Sollicitatiebeheer.Data.EFCore;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    [DbContext(typeof(SollicitatiebeheerContext))]
    [Migration("20170613170304_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sollicitatiebeheer.Model.Vacatures.Vacature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Afdeling");

                    b.Property<string>("Functie");

                    b.Property<bool>("IsGearchiveerd");

                    b.Property<string>("Omschrijving");

                    b.Property<string>("Vacaturenummer");

                    b.HasKey("Id");

                    b.ToTable("Vacatures");
                });
        }
    }
}
