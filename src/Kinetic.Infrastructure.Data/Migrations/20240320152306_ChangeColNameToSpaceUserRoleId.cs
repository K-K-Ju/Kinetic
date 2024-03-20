using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinetic.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColNameToSpaceUserRoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceUsers_Roles_UserRoleId",
                schema: "application",
                table: "SpaceUsers");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                schema: "application",
                table: "SpaceUsers",
                newName: "SpaceUserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceUsers_UserRoleId",
                schema: "application",
                table: "SpaceUsers",
                newName: "IX_SpaceUsers_SpaceUserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceUsers_Roles_SpaceUserRoleId",
                schema: "application",
                table: "SpaceUsers",
                column: "SpaceUserRoleId",
                principalSchema: "application",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceUsers_Roles_SpaceUserRoleId",
                schema: "application",
                table: "SpaceUsers");

            migrationBuilder.RenameColumn(
                name: "SpaceUserRoleId",
                schema: "application",
                table: "SpaceUsers",
                newName: "UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceUsers_SpaceUserRoleId",
                schema: "application",
                table: "SpaceUsers",
                newName: "IX_SpaceUsers_UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceUsers_Roles_UserRoleId",
                schema: "application",
                table: "SpaceUsers",
                column: "UserRoleId",
                principalSchema: "application",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
