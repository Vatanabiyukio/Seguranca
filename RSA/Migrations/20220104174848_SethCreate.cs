using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSA.Migrations
{
    public partial class SethCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Comum_ComumId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Privada_PrivadaId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Publica_PublicaId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_ComumId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_PrivadaId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_PublicaId",
                table: "Mensagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ComumId",
                table: "Mensagem",
                column: "ComumId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_PrivadaId",
                table: "Mensagem",
                column: "PrivadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_PublicaId",
                table: "Mensagem",
                column: "PublicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Comum_ComumId",
                table: "Mensagem",
                column: "ComumId",
                principalTable: "Comum",
                principalColumn: "Id");

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
    }
}
