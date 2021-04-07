using PokemonTrainerAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Repository.Interfaces
{
    public interface IPokemonRepository
    {
        void InserirPokemon(Pokemon pokemon);
        IList<Pokemon> ListarPokemons(Usuario user);
    }
}
