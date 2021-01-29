using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchitectDevicesCR.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCardId",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Site",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "Device",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Device",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Device",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Device",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Device",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    UserCardId = table.Column<int>(nullable: false),
                    CheckedOut = table.Column<DateTime>(nullable: false),
                    CheckedIn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_UserCards_UserCardId",
                        column: x => x.UserCardId,
                        principalTable: "UserCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    UserCardId = table.Column<int>(nullable: true),
                    Since = table.Column<DateTime>(nullable: false),
                    Until = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkouts_UserCards_UserCardId",
                        column: x => x.UserCardId,
                        principalTable: "UserCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: true),
                    UserCardId = table.Column<int>(nullable: true),
                    HoldPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holds_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_UserCards_UserCardId",
                        column: x => x.UserCardId,
                        principalTable: "UserCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCardId",
                table: "User",
                column: "UserCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_SiteId",
                table: "Device",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_StatusId",
                table: "Device",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_DeviceId",
                table: "CheckoutHistories",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_UserCardId",
                table: "CheckoutHistories",
                column: "UserCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_DeviceId",
                table: "Checkouts",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_UserCardId",
                table: "Checkouts",
                column: "UserCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_DeviceId",
                table: "Holds",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_UserCardId",
                table: "Holds",
                column: "UserCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Site_SiteId",
                table: "Device",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Statuses_StatusId",
                table: "Device",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserCards_UserCardId",
                table: "User",
                column: "UserCardId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Site_SiteId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Statuses_StatusId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserCards_UserCardId",
                table: "User");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_User_UserCardId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Device_SiteId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_StatusId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "UserCardId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Device");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "Device",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Device",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
