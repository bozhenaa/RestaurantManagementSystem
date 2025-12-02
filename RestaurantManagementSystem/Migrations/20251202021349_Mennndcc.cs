using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Mennndcc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItems_MenuItems_MenuItemsId",
                table: "MenuMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItems_Menu_MenuId",
                table: "MenuMenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMenuItems",
                table: "MenuMenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuMenuItems_MenuItemsId",
                table: "MenuMenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "MenuMenuItems",
                newName: "MenuMenuItem");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "MenuMenuItem",
                newName: "MenusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMenuItem",
                table: "MenuMenuItem",
                columns: new[] { "MenuItemsId", "MenusId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuItem_MenusId",
                table: "MenuMenuItem",
                column: "MenusId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_MenuItems_MenuItemsId",
                table: "MenuMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMenuItem_Menus_MenusId",
                table: "MenuMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMenuItem",
                table: "MenuMenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuMenuItem_MenusId",
                table: "MenuMenuItem");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "MenuMenuItem",
                newName: "MenuMenuItems");

            migrationBuilder.RenameColumn(
                name: "MenusId",
                table: "MenuMenuItems",
                newName: "MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMenuItems",
                table: "MenuMenuItems",
                columns: new[] { "MenuId", "MenuItemsId" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuItems_MenuItemsId",
                table: "MenuMenuItems",
                column: "MenuItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItems_MenuItems_MenuItemsId",
                table: "MenuMenuItems",
                column: "MenuItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMenuItems_Menu_MenuId",
                table: "MenuMenuItems",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
