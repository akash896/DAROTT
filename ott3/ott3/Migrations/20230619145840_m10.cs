using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollFiles_Polls_Polluid",
                table: "PollFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollFiles",
                table: "PollFiles");

            migrationBuilder.DropIndex(
                name: "IX_PollFiles_Polluid",
                table: "PollFiles");

            migrationBuilder.DropColumn(
                name: "voteUid",
                table: "PollFiles");

            migrationBuilder.RenameColumn(
                name: "Polluid",
                table: "PollFiles",
                newName: "pollUid");

            migrationBuilder.AlterColumn<int>(
                name: "pollUid",
                table: "PollFiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollFiles",
                table: "PollFiles",
                columns: new[] { "pollUid", "fileUid" });

            migrationBuilder.AddForeignKey(
                name: "FK_PollFiles_Polls_pollUid",
                table: "PollFiles",
                column: "pollUid",
                principalTable: "Polls",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollFiles_Polls_pollUid",
                table: "PollFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollFiles",
                table: "PollFiles");

            migrationBuilder.RenameColumn(
                name: "pollUid",
                table: "PollFiles",
                newName: "Polluid");

            migrationBuilder.AlterColumn<int>(
                name: "Polluid",
                table: "PollFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "voteUid",
                table: "PollFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollFiles",
                table: "PollFiles",
                columns: new[] { "voteUid", "fileUid" });

            migrationBuilder.CreateIndex(
                name: "IX_PollFiles_Polluid",
                table: "PollFiles",
                column: "Polluid");

            migrationBuilder.AddForeignKey(
                name: "FK_PollFiles_Polls_Polluid",
                table: "PollFiles",
                column: "Polluid",
                principalTable: "Polls",
                principalColumn: "uid");
        }
    }
}
