using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afdelingen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsGearchiveerd = table.Column<bool>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    TijdstipAangemaaktUtc = table.Column<DateTime>(nullable: false),
                    TijdstipLaatstGewijzigdUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdelingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    AfdelingId = table.Column<int>(nullable: false),
                    Functie = table.Column<string>(nullable: true),
                    IsGearchiveerd = table.Column<bool>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    TijdstipAangemaaktUtc = table.Column<DateTime>(nullable: false),
                    TijdstipLaatstGewijzigdUtc = table.Column<DateTime>(nullable: false),
                    Vacaturenummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacatures_Afdelingen_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdelingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacatures_AfdelingId",
                table: "Vacatures",
                column: "AfdelingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacatures");

            migrationBuilder.DropTable(
                name: "Afdelingen");
        }
    }
}
