using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Services.Interfaces
{
    public interface IPokemonService
    {
        bool AdicionarPokemon(string nome, string email);
        IList<PokemonOutDTO> ListarPokemonsDoUser(string email);
    }
}
