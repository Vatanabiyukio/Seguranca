using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSA.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ComumId",
                table: "Mensagem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ComumId",
                table: "Mensagem",
                column: "ComumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Comum_ComumId",
                table: "Mensagem",
                column: "ComumId",
                principalTable: "Comum",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Comum_ComumId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_ComumId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "ComumId",
                table: "Mensagem");
        }
    }
}
