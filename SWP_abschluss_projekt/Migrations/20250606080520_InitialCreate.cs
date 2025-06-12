using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP_abschluss_projekt.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raeume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raeume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faecher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: false),
                    LehrerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faecher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klassen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    KlassenvorstandId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klassen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", nullable: false),
                    PersonTyp = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    KlasseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Klassen_KlasseId",
                        column: x => x.KlasseId,
                        principalTable: "Klassen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stundenplaene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KlasseId = table.Column<int>(type: "INTEGER", nullable: true),
                    FachId = table.Column<int>(type: "INTEGER", nullable: true),
                    RaumId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stundenplaene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stundenplaene_Faecher_FachId",
                        column: x => x.FachId,
                        principalTable: "Faecher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stundenplaene_Klassen_KlasseId",
                        column: x => x.KlasseId,
                        principalTable: "Klassen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stundenplaene_Raeume_RaumId",
                        column: x => x.RaumId,
                        principalTable: "Raeume",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Noten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wert = table.Column<int>(type: "INTEGER", nullable: false),
                    SchuelerId = table.Column<int>(type: "INTEGER", nullable: true),
                    FachId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noten_Faecher_FachId",
                        column: x => x.FachId,
                        principalTable: "Faecher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Noten_Person_SchuelerId",
                        column: x => x.SchuelerId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faecher_LehrerId",
                table: "Faecher",
                column: "LehrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Klassen_KlassenvorstandId",
                table: "Klassen",
                column: "KlassenvorstandId");

            migrationBuilder.CreateIndex(
                name: "IX_Noten_FachId",
                table: "Noten",
                column: "FachId");

            migrationBuilder.CreateIndex(
                name: "IX_Noten_SchuelerId",
                table: "Noten",
                column: "SchuelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_KlasseId",
                table: "Person",
                column: "KlasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Stundenplaene_FachId",
                table: "Stundenplaene",
                column: "FachId");

            migrationBuilder.CreateIndex(
                name: "IX_Stundenplaene_KlasseId",
                table: "Stundenplaene",
                column: "KlasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Stundenplaene_RaumId",
                table: "Stundenplaene",
                column: "RaumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faecher_Person_LehrerId",
                table: "Faecher",
                column: "LehrerId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Klassen_Person_KlassenvorstandId",
                table: "Klassen",
                column: "KlassenvorstandId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klassen_Person_KlassenvorstandId",
                table: "Klassen");

            migrationBuilder.DropTable(
                name: "Noten");

            migrationBuilder.DropTable(
                name: "Stundenplaene");

            migrationBuilder.DropTable(
                name: "Faecher");

            migrationBuilder.DropTable(
                name: "Raeume");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Klassen");
        }
    }
}
