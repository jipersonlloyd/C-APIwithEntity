using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_BackendEntity.Migrations
{
    /// <inheritdoc />
    public partial class JwToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AccountModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AccountModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AccountModel");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AccountModel");
        }
    }
}
