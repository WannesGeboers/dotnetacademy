using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNETacademy.Migrations
{
    public partial class deelnemerId_toegevoegd_aan_Evaluatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluatie_Deelnemer_DeelnemerId",
                table: "Evaluatie");

            migrationBuilder.AlterColumn<int>(
                name: "DeelnemerId",
                table: "Evaluatie",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluatie_Deelnemer_DeelnemerId",
                table: "Evaluatie",
                column: "DeelnemerId",
                principalTable: "Deelnemer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluatie_Deelnemer_DeelnemerId",
                table: "Evaluatie");

            migrationBuilder.AlterColumn<int>(
                name: "DeelnemerId",
                table: "Evaluatie",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluatie_Deelnemer_DeelnemerId",
                table: "Evaluatie",
                column: "DeelnemerId",
                principalTable: "Deelnemer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
