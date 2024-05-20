using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation_Foyer.Migrations
{
    /// <inheritdoc />
    public partial class amine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoyerUniversite",
                columns: table => new
                {
                    FoyersId = table.Column<int>(type: "int", nullable: false),
                    UniversitesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoyerUniversite", x => new { x.FoyersId, x.UniversitesId });
                    table.ForeignKey(
                        name: "FK_FoyerUniversite_Foyer_FoyersId",
                        column: x => x.FoyersId,
                        principalTable: "Foyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoyerUniversite_Universite_UniversitesId",
                        column: x => x.UniversitesId,
                        principalTable: "Universite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Cin = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UniversiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Universite_UniversiteId",
                        column: x => x.UniversiteId,
                        principalTable: "Universite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoyerUniversite_UniversitesId",
                table: "FoyerUniversite",
                column: "UniversitesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversiteId",
                table: "Users",
                column: "UniversiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoyerUniversite");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Foyer");

            migrationBuilder.DropTable(
                name: "Universite");
        }
    }
}
