using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTLongChau.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductUpdateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryInformationId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PayModeId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipModeId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryInformation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayModes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipModes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipModes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryInformationId",
                table: "Orders",
                column: "DeliveryInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PayModeId",
                table: "Orders",
                column: "PayModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipModeId",
                table: "Orders",
                column: "ShipModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryInformation_DeliveryInformationId",
                table: "Orders",
                column: "DeliveryInformationId",
                principalTable: "DeliveryInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PayModes_PayModeId",
                table: "Orders",
                column: "PayModeId",
                principalTable: "PayModes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShipModes_ShipModeId",
                table: "Orders",
                column: "ShipModeId",
                principalTable: "ShipModes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryInformation_DeliveryInformationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PayModes_PayModeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShipModes_ShipModeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryInformation");

            migrationBuilder.DropTable(
                name: "PayModes");

            migrationBuilder.DropTable(
                name: "ShipModes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryInformationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PayModeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipModeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryInformationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PayModeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipModeId",
                table: "Orders");
        }
    }
}
