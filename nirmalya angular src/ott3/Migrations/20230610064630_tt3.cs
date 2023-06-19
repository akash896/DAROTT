using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ott3.Migrations
{
    /// <inheritdoc />
    public partial class tt3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "awslink",
                table: "MovieFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "awslink",
                table: "MovieFiles");
        }
    }
}
