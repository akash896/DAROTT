using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PollFile",
                columns: table => new
                {
                    pollUid = table.Column<int>(type: "int", nullable: false),
                    fileUid = table.Column<int>(type: "int", nullable: false),
                    photoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollFile", x => new { x.pollUid, x.fileUid });
                    table.ForeignKey(
                        name: "FK_PollFile_Files_fileUid",
                        column: x => x.fileUid,
                        principalTable: "Files",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollFile_Polls_pollUid",
                        column: x => x.pollUid,
                        principalTable: "Polls",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollFile_fileUid",
                table: "PollFile",
                column: "fileUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollFile");
        }
    }
}
