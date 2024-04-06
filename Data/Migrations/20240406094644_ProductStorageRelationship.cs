using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTLongChau.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductStorageRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StorageId",
                table: "Products",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Storages_StorageId",
                table: "Products",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Storages_StorageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_Products_StorageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Products");
        }
    }
}
