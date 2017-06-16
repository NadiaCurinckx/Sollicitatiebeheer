using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Sollicitatiebeheer.Data.EFCore;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    [DbContext(typeof(SollicitatiebeheerContext))]
    partial class SollicitatiebeheerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sollicitatiebeheer.Model.Afdelingen.Afdeling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsGearchiveerd");

                    b.Property<string>("Naam");

                    b.Property<DateTime>("TijdstipAangemaaktUtc");

                    b.Property<DateTime>("TijdstipLaatstGewijzigdUtc");

                    b.HasKey("Id");

                    b.ToTable("Afdelingen");
                });

            modelBuilder.Entity("Sollicitatiebeheer.Model.Vacatures.Vacature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<int>("AfdelingId");

                    b.Property<string>("Functie");

                    b.Property<bool>("IsGearchiveerd");

                    b.Property<string>("Omschrijving");

                    b.Property<DateTime>("TijdstipAangemaaktUtc");

                    b.Property<DateTime>("TijdstipLaatstGewijzigdUtc");

                    b.Property<string>("Vacaturenummer");

                    b.HasKey("Id");

                    b.HasIndex("AfdelingId");

                    b.ToTable("Vacatures");
                });

            modelBuilder.Entity("Sollicitatiebeheer.Model.Vacatures.Vacature", b =>
                {
                    b.HasOne("Sollicitatiebeheer.Model.Afdelingen.Afdeling", "Afdeling")
                        .WithMany()
                        .HasForeignKey("AfdelingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
