using Microsoft.EntityFrameworkCore.Migrations;

namespace LaywerApp.Repositories.Migrations
{
    public partial class AddingUsernameAndPasswordProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Collaborators",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Collaborators",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Collaborators");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Collaborators");
        }
    }
}
