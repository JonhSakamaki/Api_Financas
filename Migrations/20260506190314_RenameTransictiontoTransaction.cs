using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Financas.Migrations
{
    /// <inheritdoc />
    public partial class RenameTransictiontoTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transictions_Categories_CategoryId",
                table: "Transictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transictions",
                table: "Transictions");

            migrationBuilder.RenameTable(
                name: "Transictions",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Transictions_CategoryId",
                table: "Transactions",
                newName: "IX_Transactions_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_CategoryId",
                table: "Transactions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_CategoryId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transictions");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transictions",
                newName: "IX_Transictions_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transictions",
                table: "Transictions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transictions_Categories_CategoryId",
                table: "Transictions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
