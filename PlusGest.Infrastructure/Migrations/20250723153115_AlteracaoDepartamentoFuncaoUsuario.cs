using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlusGest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoDepartamentoFuncaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Funcao",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Usuario");
        }
    }
}
