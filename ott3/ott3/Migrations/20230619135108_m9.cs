using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollFile_Files_fileUid",
                table: "PollFile");

            migrationBuilder.DropForeignKey(
                name: "FK_PollFile_Polls_Polluid",
                table: "PollFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollFile",
                table: "PollFile");

            migrationBuilder.RenameTable(
                name: "PollFile",
                newName: "PollFiles");

            migrationBuilder.RenameIndex(
                name: "IX_PollFile_Polluid",
                table: "PollFiles",
                newName: "IX_PollFiles_Polluid");

            migrationBuilder.RenameIndex(
                name: "IX_PollFile_fileUid",
                table: "PollFiles",
                newName: "IX_PollFiles_fileUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollFiles",
                table: "PollFiles",
                columns: new[] { "voteUid", "fileUid" });

            migrationBuilder.AddForeignKey(
                name: "FK_PollFiles_Files_fileUid",
                table: "PollFiles",
                column: "fileUid",
                principalTable: "Files",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollFiles_Polls_Polluid",
                table: "PollFiles",
                column: "Polluid",
                principalTable: "Polls",
                principalColumn: "uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollFiles_Files_fileUid",
                table: "PollFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PollFiles_Polls_Polluid",
                table: "PollFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollFiles",
                table: "PollFiles");

            migrationBuilder.RenameTable(
                name: "PollFiles",
                newName: "PollFile");

            migrationBuilder.RenameIndex(
                name: "IX_PollFiles_Polluid",
                table: "PollFile",
                newName: "IX_PollFile_Polluid");

            migrationBuilder.RenameIndex(
                name: "IX_PollFiles_fileUid",
                table: "PollFile",
                newName: "IX_PollFile_fileUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollFile",
                table: "PollFile",
                columns: new[] { "voteUid", "fileUid" });

            migrationBuilder.AddForeignKey(
                name: "FK_PollFile_Files_fileUid",
                table: "PollFile",
                column: "fileUid",
                principalTable: "Files",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollFile_Polls_Polluid",
                table: "PollFile",
                column: "Polluid",
                principalTable: "Polls",
                principalColumn: "uid");
        }
    }
}
