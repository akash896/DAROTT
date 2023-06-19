using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollFile_Polls_pollUid",
                table: "PollFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollFile",
                table: "PollFile");

            migrationBuilder.RenameColumn(
                name: "pollUid",
                table: "PollFile",
                newName: "Polluid");

            migrationBuilder.AddColumn<int>(
                name: "viewCount",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Polluid",
                table: "PollFile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "voteUid",
                table: "PollFile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollFile",
                table: "PollFile",
                columns: new[] { "voteUid", "fileUid" });

            migrationBuilder.CreateIndex(
                name: "IX_PollFile_Polluid",
                table: "PollFile",
                column: "Polluid");

            migrationBuilder.AddForeignKey(
                name: "FK_PollFile_Polls_Polluid",
                table: "PollFile",
                column: "Polluid",
                principalTable: "Polls",
                principalColumn: "uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollFile_Polls_Polluid",
                table: "PollFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollFile",
                table: "PollFile");

            migrationBuilder.DropIndex(
                name: "IX_PollFile_Polluid",
                table: "PollFile");

            migrationBuilder.DropColumn(
                name: "viewCount",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "voteUid",
                table: "PollFile");

            migrationBuilder.RenameColumn(
                name: "Polluid",
                table: "PollFile",
                newName: "pollUid");

            migrationBuilder.AlterColumn<int>(
                name: "pollUid",
                table: "PollFile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollFile",
                table: "PollFile",
                columns: new[] { "pollUid", "fileUid" });

            migrationBuilder.AddForeignKey(
                name: "FK_PollFile_Polls_pollUid",
                table: "PollFile",
                column: "pollUid",
                principalTable: "Polls",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
