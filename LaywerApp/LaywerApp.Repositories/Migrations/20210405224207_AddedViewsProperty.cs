using Microsoft.EntityFrameworkCore.Migrations;

namespace LaywerApp.Repositories.Migrations
{
    public partial class AddedViewsProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "LawServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Collaborators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Articles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "LawServices");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Collaborators");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Articles");
        }
    }
}
