using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudFarmaciaPagueMenos.Migrations
{
    public partial class TabelasLojaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Lojas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Lojas");
        }
    }
}
