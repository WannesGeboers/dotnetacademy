using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNETacademy.Migrations
{
    public partial class zoekuit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.DropIndex(
                name: "IX_Jaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.DropColumn(
                name: "JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.AddColumn<int>(
                name: "JaarAbonnementId",
                table: "Jaarabonnement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement",
                column: "JaarAbonnementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement",
                column: "JaarAbonnementId",
                principalTable: "TypeJaarabonnement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.DropIndex(
                name: "IX_Jaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.DropColumn(
                name: "JaarAbonnementId",
                table: "Jaarabonnement");

            migrationBuilder.AddColumn<int>(
                name: "JaarAbonnementId",
                table: "Jaarabonnement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement",
                column: "TypeJaarAbonnementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jaarabonnement_TypeJaarabonnement_JaarAbonnementId",
                table: "Jaarabonnement",
                column: "JaarAbonnementId",
                principalTable: "Jaarabonnement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
