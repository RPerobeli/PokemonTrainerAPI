using Microsoft.EntityFrameworkCore;
using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private PkTrainerContext contexto;
        public PokemonRepository(PkTrainerContext context)
        {
            contexto = context;
        }
        public void InserirPokemon(Pokemon pokemon)
        {
            contexto.pokemon.Add(pokemon);
            Commit();
        }

        public void Commit()
        {
            contexto.SaveChanges();
        }
        public IList<Pokemon> ListarPokemons(Usuario user)
        {
            IList<Pokemon> listaPokemons = contexto.pokemon.Where(w => w.idTrainer == user.id).ToList();
            if(listaPokemons.Count == 0)
            {
                throw new Exception($"{user.username} não possui nenhum pokemon");
            }
            return listaPokemons;
        }
    }
}
