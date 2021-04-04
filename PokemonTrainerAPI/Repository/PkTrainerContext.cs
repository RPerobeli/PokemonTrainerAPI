using Microsoft.EntityFrameworkCore;
using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Repository
{
    public class PkTrainerContext : DbContext
    {
        public PkTrainerContext(DbContextOptions<PkTrainerContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new PokemonMapping());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Pokemon> pokemon { get; set; }
        public DbSet<Usuario> user { get; set; }
    }
}
