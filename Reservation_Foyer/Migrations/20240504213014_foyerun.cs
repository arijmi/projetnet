using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation_Foyer.Migrations
{
    /// <inheritdoc />
    public partial class foyerun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChambreId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChambreId",
                table: "Users",
                column: "ChambreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Chambre_ChambreId",
                table: "Users",
                column: "ChambreId",
                principalTable: "Chambre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Chambre_ChambreId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChambreId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChambreId",
                table: "Users");
        }
    }
}
