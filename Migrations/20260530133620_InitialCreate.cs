using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FocusDesk.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WachtwoordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kleur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudieDoelen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoelUren = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudieDoelen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudieDoelen_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studiesessies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starttijd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eindtijd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duur = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studiesessies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studiesessies_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studiesessies_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SessieNotities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inhoud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AangemaaktOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudiesessieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessieNotities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessieNotities_Studiesessies_StudiesessieId",
                        column: x => x.StudiesessieId,
                        principalTable: "Studiesessies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessieNotities_StudiesessieId",
                table: "SessieNotities",
                column: "StudiesessieId");

            migrationBuilder.CreateIndex(
                name: "IX_StudieDoelen_GebruikerId",
                table: "StudieDoelen",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Studiesessies_GebruikerId",
                table: "Studiesessies",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Studiesessies_TagId",
                table: "Studiesessies",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessieNotities");

            migrationBuilder.DropTable(
                name: "StudieDoelen");

            migrationBuilder.DropTable(
                name: "Studiesessies");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
