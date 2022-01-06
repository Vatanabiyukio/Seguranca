using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSA.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Publica",
                table: "Mensagem",
                newName: "PublicaId");

            migrationBuilder.RenameColumn(
                name: "Privada",
                table: "Mensagem",
                newName: "PrivadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_PrivadaId",
                table: "Mensagem",
                column: "PrivadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_PublicaId",
                table: "Mensagem",
                column: "PublicaId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Privada_PrivadaId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Publica_PublicaId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_PrivadaId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_PublicaId",
                table: "Mensagem");

            migrationBuilder.RenameColumn(
                name: "PublicaId",
                table: "Mensagem",
                newName: "Publica");

            migrationBuilder.RenameColumn(
                name: "PrivadaId",
                table: "Mensagem",
                newName: "Privada");
        }
    }
}
