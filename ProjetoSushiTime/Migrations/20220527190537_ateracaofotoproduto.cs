using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSushiTime.Migrations
{
    public partial class ateracaofotoproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUTOS",
                table: "PRODUTOS");

            migrationBuilder.RenameTable(
                name: "PRODUTOS",
                newName: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Produtos",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "PRODUTOS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUTOS",
                table: "PRODUTOS",
                column: "Id");
        }
    }
}
