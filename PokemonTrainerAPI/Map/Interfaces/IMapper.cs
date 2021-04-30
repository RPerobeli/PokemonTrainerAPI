using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Map.Interfaces
{
    public interface IMapper
    {
        UserDTO Usuario2UserDTO(Usuario user);
        IList<UserDTO> Usuario2UserDTO(IList<Usuario> users);
        PokemonOutDTO Pokemon2PokemonOutDTO(Pokemon pokemon);
        IList<PokemonOutDTO> Pokemon2PokemonOutDTO(IList<Pokemon> pokemons);
        IList<PokemonOutDetailedDTO> PokemonFull2PokemonOutDetailedDTO(IList<PokemonFull> listaPokemons);
        PokemonOutDetailedDTO PokemonFull2PokemonOutDetailedDTO(PokemonFull pokemon);
        PokemonOutFullDTO PokemonFull2PokemonOutFullDTO(PokemonFull pokemonFull);
    }
}
