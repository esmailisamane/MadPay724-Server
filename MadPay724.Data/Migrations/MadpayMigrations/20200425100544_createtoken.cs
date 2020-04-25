using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MadPay724.Data.Migrations.MadpayMigrations
{
    public partial class createtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankCard_AspNetUsers_UserId",
                table: "BankCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_AspNetUsers_UserId",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankCard",
                table: "BankCard");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "BankCard",
                newName: "BankCards");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_UserId",
                table: "Photos",
                newName: "IX_Photos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BankCard_UserId",
                table: "BankCards",
                newName: "IX_BankCards_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankCards",
                table: "BankCards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datecreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    CloudinaryCloudName = table.Column<string>(nullable: false),
                    CloudinaryAPIKey = table.Column<string>(nullable: false),
                    CloudinaryAPISecret = table.Column<string>(nullable: false),
                    UploadLocal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Datecreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    ExpireDate = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankCards_AspNetUsers_UserId",
                table: "BankCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankCards_AspNetUsers_UserId",
                table: "BankCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankCards",
                table: "BankCards");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "BankCards",
                newName: "BankCard");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_UserId",
                table: "Photo",
                newName: "IX_Photo_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BankCards_UserId",
                table: "BankCard",
                newName: "IX_BankCard_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankCard",
                table: "BankCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankCard_AspNetUsers_UserId",
                table: "BankCard",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_AspNetUsers_UserId",
                table: "Photo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
