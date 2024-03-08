using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinetic.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailAndIdentityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "application",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                schema: "application",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "application",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                schema: "application",
                table: "Users");
        }
    }
}
