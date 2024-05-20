﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation_Foyer.Migrations
{
    /// <inheritdoc />
    public partial class foyeruni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chambre",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chambre");
        }
    }
}
