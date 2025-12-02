using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class eqrgeh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemsId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusId",
                table: "MenuMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMenuItem",
                table: "MenuMenuItem");

            migrationBuilder.RenameTable(
                name: "MenuMenuItem",
                newName: "MenuMenuItems");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMenuItem_MenusId",
                table: "MenuMenuItems",
                newName: "IX_MenuMenuItems_MenusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMenuItems",
                table: "MenuMenuItems",
                columns: new[] { "MenuItemsId", "MenusId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItems_MenuItems_MenuItemsId",
                table: "MenuMenuItems",
                column: "MenuItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItems_Menus_MenusId",
                table: "MenuMenuItems",
                column: "MenusId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItems_MenuItems_MenuItemsId",
                table: "MenuMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItems_Menus_MenusId",
                table: "MenuMenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMenuItems",
                table: "MenuMenuItems");

            migrationBuilder.RenameTable(
                name: "MenuMenuItems",
                newName: "MenuMenuItem");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMenuItems_MenusId",
                table: "MenuMenuItem",
                newName: "IX_MenuMenuItem_MenusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMenuItem",
                table: "MenuMenuItem",
                columns: new[] { "MenuItemsId", "MenusId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemsId",
                table: "MenuMenuItem",
                column: "MenuItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusId",
                table: "MenuMenuItem",
                column: "MenusId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
