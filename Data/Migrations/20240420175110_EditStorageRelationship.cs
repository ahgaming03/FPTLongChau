using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTLongChau.Data.Migrations
{
	/// <inheritdoc />
	public partial class EditStorageRelationship : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_Storages",
				table: "Storages");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Storages",
				table: "Storages",
				column: "Id");

			migrationBuilder.CreateIndex(
				name: "IX_Storages_SupplierId",
				table: "Storages",
				column: "SupplierId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_Storages",
				table: "Storages");

			migrationBuilder.DropIndex(
				name: "IX_Storages_SupplierId",
				table: "Storages");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Storages",
				table: "Storages",
				columns: new[] { "SupplierId", "ProductId" });
		}
	}
}
