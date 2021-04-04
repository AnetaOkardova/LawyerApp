using Microsoft.EntityFrameworkCore.Migrations;

namespace LaywerApp.Repositories.Migrations
{
    public partial class AddedIsAdminProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Collaborators",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Collaborators");
        }
    }
}
