using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSA.Migrations
{
    public partial class OitoCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComumId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "PrivadaId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "PublicaId",
                table: "Mensagem");

            migrationBuilder.AddColumn<Guid>(
                name: "ChaveComumId",
                table: "Mensagem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChavePrivadaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChavePublicaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ChaveComumId",
                table: "Mensagem",
                column: "ChaveComumId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ChavePrivadaId",
                table: "Mensagem",
                column: "ChavePrivadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ChavePublicaId",
                table: "Mensagem",
                column: "ChavePublicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Comum_ChaveComumId",
                table: "Mensagem",
                column: "ChaveComumId",
                principalTable: "Comum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Privada_ChavePrivadaId",
                table: "Mensagem",
                column: "ChavePrivadaId",
                principalTable: "Privada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Publica_ChavePublicaId",
                table: "Mensagem",
                column: "ChavePublicaId",
                principalTable: "Publica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Comum_ChaveComumId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Privada_ChavePrivadaId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Publica_ChavePublicaId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_ChaveComumId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_ChavePrivadaId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_ChavePublicaId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "ChaveComumId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "ChavePrivadaId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "ChavePublicaId",
                table: "Mensagem");

            migrationBuilder.AddColumn<Guid>(
                name: "ComumId",
                table: "Mensagem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrivadaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PublicaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: true);
        }
    }
}
