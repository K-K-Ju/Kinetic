using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinetic.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "application");

            migrationBuilder.CreateTable(
                name: "SpaceBackLogs",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentSpaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceBackLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitiatorId = table.Column<int>(type: "int", nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpaceBackLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_SpaceBackLogs_SpaceBackLogId",
                        column: x => x.SpaceBackLogId,
                        principalSchema: "application",
                        principalTable: "SpaceBackLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spaces",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    SpaceBackLogId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaces_SpaceBackLogs_SpaceBackLogId",
                        column: x => x.SpaceBackLogId,
                        principalSchema: "application",
                        principalTable: "SpaceBackLogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Spaces_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "application",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalSchema: "application",
                        principalTable: "Spaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpaceUsers",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    SpaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaceUsers_Roles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "application",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpaceUsers_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalSchema: "application",
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpaceUsers_Users_Id",
                        column: x => x.Id,
                        principalSchema: "application",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: false),
                    SpaceId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_SpaceUsers_AssignedToId",
                        column: x => x.AssignedToId,
                        principalSchema: "application",
                        principalTable: "SpaceUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_SpaceUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "application",
                        principalTable: "SpaceUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalSchema: "application",
                        principalTable: "Spaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "application",
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "application",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Tags_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "application",
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Restrictions",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestrictedTicketActions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    TagName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restrictions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "application",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Restrictions_Tags_TagName",
                        column: x => x.TagName,
                        principalSchema: "application",
                        principalTable: "Tags",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SpaceBackLogId",
                schema: "application",
                table: "Logs",
                column: "SpaceBackLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Restrictions_RoleId",
                schema: "application",
                table: "Restrictions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Restrictions_TagName",
                schema: "application",
                table: "Restrictions",
                column: "TagName");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_SpaceId",
                schema: "application",
                table: "Roles",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_OwnerId",
                schema: "application",
                table: "Spaces",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_SpaceBackLogId",
                schema: "application",
                table: "Spaces",
                column: "SpaceBackLogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpaceUsers_SpaceId",
                schema: "application",
                table: "SpaceUsers",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceUsers_UserRoleId",
                schema: "application",
                table: "SpaceUsers",
                column: "UserRoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TicketId",
                schema: "application",
                table: "Tags",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedToId",
                schema: "application",
                table: "Tickets",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatorId",
                schema: "application",
                table: "Tickets",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SpaceId",
                schema: "application",
                table: "Tickets",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketId",
                schema: "application",
                table: "Tickets",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Restrictions",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "application");

            migrationBuilder.DropTable(
                name: "SpaceUsers",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Spaces",
                schema: "application");

            migrationBuilder.DropTable(
                name: "SpaceBackLogs",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "application");
        }
    }
}
