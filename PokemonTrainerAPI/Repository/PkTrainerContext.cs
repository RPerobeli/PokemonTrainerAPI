using Microsoft.EntityFrameworkCore;
using PokemonTrainerAPI.Domain;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost\SQLEXPRESS;Database=PkTrainer;Integrated Security=True");
        }
        public DbSet<Pokemon> pokemon { get; set; }
        public DbSet<Usuario> user { get; set; }
    }
}
