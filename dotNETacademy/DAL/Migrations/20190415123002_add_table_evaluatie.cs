using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNETacademy.Migrations
{
    public partial class add_table_evaluatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluatie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    DeelnemerId = table.Column<int>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true),
                    Punt = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluatie_Deelnemer_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Deelnemer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BestandUrl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pad = table.Column<string>(nullable: true),
                    EvaluatieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestandUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BestandUrl_Evaluatie_EvaluatieId",
                        column: x => x.EvaluatieId,
                        principalTable: "Evaluatie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BestandUrl_EvaluatieId",
                table: "BestandUrl",
                column: "EvaluatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluatie_DeelnemerId",
                table: "Evaluatie",
                column: "DeelnemerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestandUrl");

            migrationBuilder.DropTable(
                name: "Evaluatie");
        }
    }
}
