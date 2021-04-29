using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonTrainerAPI.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pokemon",
                table: "pokemon");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "tb_usuarios");

            migrationBuilder.RenameTable(
                name: "pokemon",
                newName: "tb_Pokemons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Pokemons",
                table: "tb_Pokemons",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Pokemons",
                table: "tb_Pokemons");

            migrationBuilder.RenameTable(
                name: "tb_usuarios",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "tb_Pokemons",
                newName: "pokemon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pokemon",
                table: "pokemon",
                column: "id");
        }
    }
}
