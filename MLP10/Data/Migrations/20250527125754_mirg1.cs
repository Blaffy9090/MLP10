using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLP10.Migrations
{
    /// <inheritdoc />
    public partial class mirg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartaments",
                columns: table => new
                {
                    ApartamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartamentNumber = table.Column<int>(type: "int", nullable: true),
                    ApartamentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartaments", x => x.ApartamentId);
                });

            migrationBuilder.CreateTable(
                name: "Gosts",
                columns: table => new
                {
                    GostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birht = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pasport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gosts", x => x.GostId);
                });

            migrationBuilder.CreateTable(
                name: "Arendas",
                columns: table => new
                {
                    ArendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartamentId = table.Column<int>(type: "int", nullable: false),
                    GostId = table.Column<int>(type: "int", nullable: false),
                    DateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arendas", x => x.ArendaId);
                    table.ForeignKey(
                        name: "FK_Arendas_Apartaments_ApartamentId",
                        column: x => x.ApartamentId,
                        principalTable: "Apartaments",
                        principalColumn: "ApartamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arendas_Gosts_GostId",
                        column: x => x.GostId,
                        principalTable: "Gosts",
                        principalColumn: "GostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arendas_ApartamentId",
                table: "Arendas",
                column: "ApartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Arendas_GostId",
                table: "Arendas",
                column: "GostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arendas");

            migrationBuilder.DropTable(
                name: "Apartaments");

            migrationBuilder.DropTable(
                name: "Gosts");
        }
    }
}
