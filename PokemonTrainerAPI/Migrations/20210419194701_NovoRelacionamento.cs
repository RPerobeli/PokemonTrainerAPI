using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonTrainerAPI.Migrations
{
    public partial class NovoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_Pokemons_idTrainer",
                table: "tb_Pokemons",
                column: "idTrainer");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Pokemons_tb_usuarios_idTrainer",
                table: "tb_Pokemons",
                column: "idTrainer",
                principalTable: "tb_usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Pokemons_tb_usuarios_idTrainer",
                table: "tb_Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_tb_Pokemons_idTrainer",
                table: "tb_Pokemons");
        }
    }
}
