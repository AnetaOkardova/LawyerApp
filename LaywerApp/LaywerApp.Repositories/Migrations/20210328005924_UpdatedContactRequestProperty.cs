using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaywerApp.Repositories.Migrations
{
    public partial class UpdatedContactRequestProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSent",
                table: "ContactRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateSent",
                table: "ContactRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
