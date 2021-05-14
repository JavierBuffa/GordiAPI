using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class MemberRito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Teams_UserTeamId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "UserTeamId",
                table: "Members",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_UserTeamId",
                table: "Members",
                newName: "IX_Members_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Members",
                newName: "UserTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                newName: "IX_Members_UserTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Teams_UserTeamId",
                table: "Members",
                column: "UserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
