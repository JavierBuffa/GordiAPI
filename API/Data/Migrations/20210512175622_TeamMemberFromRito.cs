using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class TeamMemberFromRito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Teams_UserTeamId",
                table: "TeamMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.RenameTable(
                name: "TeamMember",
                newName: "Members");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMember_UserTeamId",
                table: "Members",
                newName: "IX_Members_UserTeamId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Members",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "IdSummoner",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Teams_UserTeamId",
                table: "Members",
                column: "UserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Teams_UserTeamId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IdSummoner",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "TeamMember");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TeamMember",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Members_UserTeamId",
                table: "TeamMember",
                newName: "IX_TeamMember_UserTeamId");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "TeamMember",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Teams_UserTeamId",
                table: "TeamMember",
                column: "UserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
