using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchitectDevicesCR.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_Device_DeviceId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Device_DeviceId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Site_SiteId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Statuses_StatusId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_Device_DeviceId",
                table: "Holds");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Site_SiteId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserCards_UserCardId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "Sites");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserCardId",
                table: "Users",
                newName: "IX_Users_UserCardId");

            migrationBuilder.RenameIndex(
                name: "IX_User_SiteId",
                table: "Users",
                newName: "IX_Users_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Device_StatusId",
                table: "Devices",
                newName: "IX_Devices_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Device_SiteId",
                table: "Devices",
                newName: "IX_Devices_SiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sites",
                table: "Sites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_Devices_DeviceId",
                table: "CheckoutHistories",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Devices_DeviceId",
                table: "Checkouts",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Sites_SiteId",
                table: "Devices",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Statuses_StatusId",
                table: "Devices",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_Devices_DeviceId",
                table: "Holds",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sites_SiteId",
                table: "Users",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCards_UserCardId",
                table: "Users",
                column: "UserCardId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_Devices_DeviceId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Devices_DeviceId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Sites_SiteId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Statuses_StatusId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_Devices_DeviceId",
                table: "Holds");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sites_SiteId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCards_UserCardId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sites",
                table: "Sites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Sites",
                newName: "Site");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserCardId",
                table: "User",
                newName: "IX_User_UserCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SiteId",
                table: "User",
                newName: "IX_User_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_StatusId",
                table: "Device",
                newName: "IX_Device_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_SiteId",
                table: "Device",
                newName: "IX_Device_SiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_Device_DeviceId",
                table: "CheckoutHistories",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Device_DeviceId",
                table: "Checkouts",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Holds_Device_DeviceId",
                table: "Holds",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Site_SiteId",
                table: "User",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserCards_UserCardId",
                table: "User",
                column: "UserCardId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
