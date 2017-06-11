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

            modelBuilder.Entity("Sollicitatiebeheer.Model.Vacatures.Vacature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("Vacatures");
                });
        }
    }
}
