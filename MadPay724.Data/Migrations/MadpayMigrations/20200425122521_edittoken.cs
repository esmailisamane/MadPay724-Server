using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MadPay724.Data.Migrations.MadpayMigrations
{
    public partial class edittoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Tokens");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireTime",
                table: "Tokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Tokens",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireTime",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "Tokens");

            migrationBuilder.AddColumn<string>(
                name: "ExpireDate",
                table: "Tokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
