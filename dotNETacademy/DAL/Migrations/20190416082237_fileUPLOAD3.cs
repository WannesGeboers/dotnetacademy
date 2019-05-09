using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNETacademy.Migrations
{
    public partial class fileUPLOAD3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BestandLocatie",
                table: "Evaluatie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestandLocatie",
                table: "Evaluatie");
        }
    }
}
