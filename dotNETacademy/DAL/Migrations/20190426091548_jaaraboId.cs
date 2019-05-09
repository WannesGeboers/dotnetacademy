using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNETacademy.Migrations
{
    public partial class jaaraboId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.AlterColumn<int>(
                name: "JaarAbonnementId",
                table: "Jaarabonnement",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement",
                column: "JaarAbonnementId",
                principalTable: "TypeJaarabonnement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.AlterColumn<int>(
                name: "JaarAbonnementId",
                table: "Jaarabonnement",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement",
                column: "JaarAbonnementId",
                principalTable: "TypeJaarabonnement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
