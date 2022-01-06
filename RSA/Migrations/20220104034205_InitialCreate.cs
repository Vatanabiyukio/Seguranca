using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Msg = table.Column<string>(type: "TEXT", nullable: false),
                    Criptografada = table.Column<bool>(type: "INTEGER", nullable: false),
                    Privada = table.Column<Guid>(type: "TEXT", nullable: false),
                    Publica = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    D = table.Column<int>(type: "INTEGER", nullable: false),
                    N = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    E = table.Column<int>(type: "INTEGER", nullable: false),
                    N = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publica", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comum");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Privada");

            migrationBuilder.DropTable(
                name: "Publica");
        }
    }
}
