using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrewCategories",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewCategories", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    updatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    admin = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    updatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genreUid = table.Column<int>(type: "int", nullable: false),
                    maturityRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    releaseYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    introStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    introEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    updatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.uid);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_genreUid",
                        column: x => x.genreUid,
                        principalTable: "Genres",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userUid = table.Column<int>(type: "int", nullable: false),
                    sessionId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    sessionPass = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    updatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.uid);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_userUid",
                        column: x => x.userUid,
                        principalTable: "Users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryUid = table.Column<int>(type: "int", nullable: false),
                    castingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieUid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.uid);
                    table.ForeignKey(
                        name: "FK_Crews_CrewCategories_categoryUid",
                        column: x => x.categoryUid,
                        principalTable: "CrewCategories",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crews_Movies_movieUid",
                        column: x => x.movieUid,
                        principalTable: "Movies",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePosters",
                columns: table => new
                {
                    movieUid = table.Column<int>(type: "int", nullable: false),
                    fileUid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePosters", x => new { x.movieUid, x.fileUid });
                    table.ForeignKey(
                        name: "FK_MoviePosters_Files_fileUid",
                        column: x => x.fileUid,
                        principalTable: "Files",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePosters_Movies_movieUid",
                        column: x => x.movieUid,
                        principalTable: "Movies",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_categoryUid",
                table: "Crews",
                column: "categoryUid");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_movieUid",
                table: "Crews",
                column: "movieUid");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePosters_fileUid",
                table: "MoviePosters",
                column: "fileUid");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genreUid",
                table: "Movies",
                column: "genreUid");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_userUid",
                table: "UserSessions",
                column: "userUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "MoviePosters");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "CrewCategories");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
