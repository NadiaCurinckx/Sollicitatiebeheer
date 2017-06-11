using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    public partial class VacatureEntiteit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Vacatures",
                newName: "Vacaturenummer");

            migrationBuilder.AddColumn<string>(
                name: "Afdeling",
                table: "Vacatures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Functie",
                table: "Vacatures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Omschrijving",
                table: "Vacatures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Afdeling",
                table: "Vacatures");

            migrationBuilder.DropColumn(
                name: "Functie",
                table: "Vacatures");

            migrationBuilder.DropColumn(
                name: "Omschrijving",
                table: "Vacatures");

            migrationBuilder.RenameColumn(
                name: "Vacaturenummer",
                table: "Vacatures",
                newName: "Naam");
        }
    }
}
