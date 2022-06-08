using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSushiTime.Migrations
{
    public partial class MODCLient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "CLIENTES",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "CLIENTES",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "CLIENTES",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCasa",
                table: "CLIENTES",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "NumeroCasa",
                table: "CLIENTES");
        }
    }
}
