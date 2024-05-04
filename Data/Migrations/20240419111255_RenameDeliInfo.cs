using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTLongChau.Data.Migrations
{
	/// <inheritdoc />
	public partial class RenameDeliInfo : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Orders_DeliveryInformation_DeliveryInformationId",
				table: "Orders");

			migrationBuilder.DropPrimaryKey(
				name: "PK_DeliveryInformation",
				table: "DeliveryInformation");

			migrationBuilder.DropColumn(
				name: "UnitId",
				table: "Products");

			migrationBuilder.RenameTable(
				name: "DeliveryInformation",
				newName: "DeliveryInformations");

			migrationBuilder.AddPrimaryKey(
				name: "PK_DeliveryInformations",
				table: "DeliveryInformations",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_DeliveryInformations_DeliveryInformationId",
				table: "Orders",
				column: "DeliveryInformationId",
				principalTable: "DeliveryInformations",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Orders_DeliveryInformations_DeliveryInformationId",
				table: "Orders");

			migrationBuilder.DropPrimaryKey(
				name: "PK_DeliveryInformations",
				table: "DeliveryInformations");

			migrationBuilder.RenameTable(
				name: "DeliveryInformations",
				newName: "DeliveryInformation");

			migrationBuilder.AddColumn<Guid>(
				name: "UnitId",
				table: "Products",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AddPrimaryKey(
				name: "PK_DeliveryInformation",
				table: "DeliveryInformation",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_DeliveryInformation_DeliveryInformationId",
				table: "Orders",
				column: "DeliveryInformationId",
				principalTable: "DeliveryInformation",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
