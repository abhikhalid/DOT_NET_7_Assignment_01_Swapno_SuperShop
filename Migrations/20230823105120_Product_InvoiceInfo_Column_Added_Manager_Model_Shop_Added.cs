using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Migrations
{
    /// <inheritdoc />
    public partial class Product_InvoiceInfo_Column_Added_Manager_Model_Shop_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops",
                column: "ManagerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops",
                column: "ManagerId");
        }
    }
}
