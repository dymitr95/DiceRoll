using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceRollBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoomRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveUserId",
                table: "Rooms",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_RoomId",
                table: "users",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ActiveUserId",
                table: "Rooms",
                column: "ActiveUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_users_ActiveUserId",
                table: "Rooms",
                column: "ActiveUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Rooms_RoomId",
                table: "users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_users_ActiveUserId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Rooms_RoomId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_RoomId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ActiveUserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ActiveUserId",
                table: "Rooms");
        }
    }
}
