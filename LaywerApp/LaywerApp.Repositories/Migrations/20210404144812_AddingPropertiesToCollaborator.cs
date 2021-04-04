using Microsoft.EntityFrameworkCore.Migrations;

namespace LaywerApp.Repositories.Migrations
{
    public partial class AddingPropertiesToCollaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Collaborators",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "LastNameInLatin",
                table: "Collaborators",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameInLatin",
                table: "Collaborators",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNameInLatin",
                table: "Collaborators");

            migrationBuilder.DropColumn(
                name: "NameInLatin",
                table: "Collaborators");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Collaborators",
                newName: "password");
        }
    }
}
