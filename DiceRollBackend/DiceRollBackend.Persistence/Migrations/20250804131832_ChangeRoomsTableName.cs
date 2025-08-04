using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceRollBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoomsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_users_ActiveUserId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Rooms_RoomId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ActiveUserId",
                table: "rooms",
                newName: "IX_rooms_ActiveUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rooms",
                table: "rooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_users_ActiveUserId",
                table: "rooms",
                column: "ActiveUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_users_rooms_RoomId",
                table: "users",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_users_ActiveUserId",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_users_rooms_RoomId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rooms",
                table: "rooms");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_ActiveUserId",
                table: "Rooms",
                newName: "IX_Rooms_ActiveUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

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
    }
}
