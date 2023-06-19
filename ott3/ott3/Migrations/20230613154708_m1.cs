using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoteFiles",
                columns: table => new
                {
                    voteUid = table.Column<int>(type: "int", nullable: false),
                    fileUid = table.Column<int>(type: "int", nullable: false),
                    photoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteFiles", x => new { x.voteUid, x.fileUid });
                    table.ForeignKey(
                        name: "FK_VoteFiles_Files_fileUid",
                        column: x => x.fileUid,
                        principalTable: "Files",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteFiles_Votes_voteUid",
                        column: x => x.voteUid,
                        principalTable: "Votes",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteFiles_fileUid",
                table: "VoteFiles",
                column: "fileUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoteFiles");
        }
    }
}
