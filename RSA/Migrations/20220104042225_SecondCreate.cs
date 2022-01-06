using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSA.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Privada_PrivadaId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Publica_PublicaId",
                table: "Mensagem");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrivadaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Privada_PrivadaId",
                table: "Mensagem",
                column: "PrivadaId",
                principalTable: "Privada",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Publica_PublicaId",
                table: "Mensagem",
                column: "PublicaId",
                principalTable: "Publica",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Privada_PrivadaId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Publica_PublicaId",
                table: "Mensagem");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PrivadaId",
                table: "Mensagem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Privada_PrivadaId",
                table: "Mensagem",
                column: "PrivadaId",
                principalTable: "Privada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Publica_PublicaId",
                table: "Mensagem",
                column: "PublicaId",
                principalTable: "Publica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
