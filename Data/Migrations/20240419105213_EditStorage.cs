using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTLongChau.Data.Migrations
{
	/// <inheritdoc />
	public partial class EditStorage : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Products_Storages_StorageId",
				table: "Products");

			migrationBuilder.DropTable(
				name: "ProductSupplier");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Storages",
				table: "Storages");

			migrationBuilder.DropIndex(
				name: "IX_Products_StorageId",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "Id",
				table: "Storages");

			migrationBuilder.DropColumn(
				name: "StorageId",
				table: "Products");

			migrationBuilder.AddColumn<Guid>(
				name: "SupplierId",
				table: "Storages",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AddColumn<Guid>(
				name: "ProductId",
				table: "Storages",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AddPrimaryKey(
				name: "PK_Storages",
				table: "Storages",
				columns: new[] { "SupplierId", "ProductId" });

			migrationBuilder.CreateIndex(
				name: "IX_Storages_ProductId",
				table: "Storages",
				column: "ProductId");

			migrationBuilder.AddForeignKey(
				name: "FK_Storages_Products_ProductId",
				table: "Storages",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Storages_Suppliers_SupplierId",
				table: "Storages",
				column: "SupplierId",
				principalTable: "Suppliers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Storages_Products_ProductId",
				table: "Storages");

			migrationBuilder.DropForeignKey(
				name: "FK_Storages_Suppliers_SupplierId",
				table: "Storages");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Storages",
				table: "Storages");

			migrationBuilder.DropIndex(
				name: "IX_Storages_ProductId",
				table: "Storages");

			migrationBuilder.DropColumn(
				name: "SupplierId",
				table: "Storages");

			migrationBuilder.DropColumn(
				name: "ProductId",
				table: "Storages");

			migrationBuilder.AddColumn<string>(
				name: "Id",
				table: "Storages",
				type: "nvarchar(450)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "StorageId",
				table: "Products",
				type: "nvarchar(450)",
				nullable: true);

			migrationBuilder.AddPrimaryKey(
				name: "PK_Storages",
				table: "Storages",
				column: "Id");

			migrationBuilder.CreateTable(
				name: "ProductSupplier",
				columns: table => new
				{
					ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					SuppliersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductsId, x.SuppliersId });
					table.ForeignKey(
						name: "FK_ProductSupplier_Products_ProductsId",
						column: x => x.ProductsId,
						principalTable: "Products",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductSupplier_Suppliers_SuppliersId",
						column: x => x.SuppliersId,
						principalTable: "Suppliers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Products_StorageId",
				table: "Products",
				column: "StorageId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductSupplier_SuppliersId",
				table: "ProductSupplier",
				column: "SuppliersId");

			migrationBuilder.AddForeignKey(
				name: "FK_Products_Storages_StorageId",
				table: "Products",
				column: "StorageId",
				principalTable: "Storages",
				principalColumn: "Id");
		}
	}
}
