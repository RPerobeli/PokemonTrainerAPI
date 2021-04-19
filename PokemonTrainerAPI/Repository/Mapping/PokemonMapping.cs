using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonTrainerAPI.Domain;

namespace PokemonTrainerAPI.Repository.Mapping
{
    public class PokemonMapping : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("tb_Pokemons");
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.nome);
            builder.Property(p => p.idTrainer).IsRequired();
            builder.HasOne(p => p.trainer).WithMany(u => u.ListaDePokemons).HasForeignKey(p => p.idTrainer).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
