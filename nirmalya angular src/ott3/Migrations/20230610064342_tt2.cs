using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class tt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "movieFileUid",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AudioLanguages",
                columns: table => new
                {
                    movieUid = table.Column<int>(type: "int", nullable: false),
                    lang = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioLanguages", x => new { x.movieUid, x.lang });
                    table.ForeignKey(
                        name: "FK_AudioLanguages_Movies_movieUid",
                        column: x => x.movieUid,
                        principalTable: "Movies",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieFiles",
                columns: table => new
                {
                    movieUid = table.Column<int>(type: "int", nullable: false),
                    fileUid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieFiles", x => new { x.movieUid, x.fileUid });
                    table.ForeignKey(
                        name: "FK_MovieFiles_Files_fileUid",
                        column: x => x.fileUid,
                        principalTable: "Files",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieFiles_Movies_movieUid",
                        column: x => x.movieUid,
                        principalTable: "Movies",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePreviews",
                columns: table => new
                {
                    movieUid = table.Column<int>(type: "int", nullable: false),
                    fileUid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePreviews", x => new { x.movieUid, x.fileUid });
                    table.ForeignKey(
                        name: "FK_MoviePreviews_Files_fileUid",
                        column: x => x.fileUid,
                        principalTable: "Files",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePreviews_Movies_movieUid",
                        column: x => x.movieUid,
                        principalTable: "Movies",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubtitleLanguages",
                columns: table => new
                {
                    movieUid = table.Column<int>(type: "int", nullable: false),
                    lang = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleLanguages", x => new { x.movieUid, x.lang });
                    table.ForeignKey(
                        name: "FK_SubtitleLanguages_Movies_movieUid",
                        column: x => x.movieUid,
                        principalTable: "Movies",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieFiles_fileUid",
                table: "MovieFiles",
                column: "fileUid");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFiles_movieUid",
                table: "MovieFiles",
                column: "movieUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviePreviews_fileUid",
                table: "MoviePreviews",
                column: "fileUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioLanguages");

            migrationBuilder.DropTable(
                name: "MovieFiles");

            migrationBuilder.DropTable(
                name: "MoviePreviews");

            migrationBuilder.DropTable(
                name: "SubtitleLanguages");

            migrationBuilder.DropColumn(
                name: "movieFileUid",
                table: "Movies");
        }
    }
}
