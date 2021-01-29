using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchitectDevicesCR.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_UserCards_UserCardId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_UserCards_UserCardId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_UserCards_UserCardId",
                table: "Holds");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCards_UserCardId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCardId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserCardId",
                table: "Holds",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_UserCardId",
                table: "Holds",
                newName: "IX_Holds_UserId");

            migrationBuilder.RenameColumn(
                name: "UserCardId",
                table: "Checkouts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_UserCardId",
                table: "Checkouts",
                newName: "IX_Checkouts_UserId");

            migrationBuilder.RenameColumn(
                name: "UserCardId",
                table: "CheckoutHistories",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckoutHistories_UserCardId",
                table: "CheckoutHistories",
                newName: "IX_CheckoutHistories_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_Users_UserId",
                table: "CheckoutHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Users_UserId",
                table: "Checkouts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_Users_UserId",
                table: "Holds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_Users_UserId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Users_UserId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_Users_UserId",
                table: "Holds");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Holds",
                newName: "UserCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_UserId",
                table: "Holds",
                newName: "IX_Holds_UserCardId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Checkouts",
                newName: "UserCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_UserId",
                table: "Checkouts",
                newName: "IX_Checkouts_UserCardId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CheckoutHistories",
                newName: "UserCardId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckoutHistories_UserId",
                table: "CheckoutHistories",
                newName: "IX_CheckoutHistories_UserCardId");

            migrationBuilder.AddColumn<int>(
                name: "UserCardId",
                table: "Users",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCardId",
                table: "Users",
                column: "UserCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_UserCards_UserCardId",
                table: "CheckoutHistories",
                column: "UserCardId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_UserCards_UserCardId",
                table: "Checkouts",
                column: "UserCardId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_UserCards_UserCardId",
                table: "Holds",
                column: "UserCardId",
                principalTable: "UserCards",
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
    }
}
