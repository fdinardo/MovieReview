using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReviewSPA.web.Migrations
{
    public partial class AddMovieCoverToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieCover",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieCover",
                table: "Movies");
        }
    }
}
