using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Map.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Map
{
    public class Mapper : IMapper
    {
        public PokemonOutDTO Pokemon2PokemonOutDTO(Pokemon pokemon)
        {
            PokemonOutDTO pokemonDto = new PokemonOutDTO();
            pokemonDto.nome = pokemon.nome;
            return pokemonDto;
        }

        public IList<PokemonOutDTO> Pokemon2PokemonOutDTO(IList<Pokemon> pokemons)
        {
            IList<PokemonOutDTO> pokemonsDto = new List<PokemonOutDTO>();
            foreach (Pokemon pokemon in pokemons)
            {
                pokemonsDto.Add(Pokemon2PokemonOutDTO(pokemon));
            }
            return pokemonsDto;
        }

        public IList<PokemonOutDetailedDTO> PokemonFull2PokemonOutDetailedDTO(IList<PokemonFull> listaPokemons)
        {
            IList<PokemonOutDetailedDTO> pokemonsDetailedDto = new List<PokemonOutDetailedDTO>();
            foreach (PokemonFull pokemon in listaPokemons)
            {
                pokemonsDetailedDto.Add(PokemonFull2PokemonOutDetailedDTO(pokemon));
            }
            return pokemonsDetailedDto;
        }

        public PokemonOutDetailedDTO PokemonFull2PokemonOutDetailedDTO(PokemonFull pokemon)
        {
            PokemonOutDetailedDTO pokemonDto = new PokemonOutDetailedDTO();
            pokemonDto.Nome = pokemon.name;
            foreach(var ability in pokemon.abilities)
            {
                pokemonDto.Abilities.Add(ability.ability.name);
            }
            foreach (var type in pokemon.types)
            {
                pokemonDto.Tipo.Add(type.type.name);
            }
            return pokemonDto;
        }

        public PokemonOutFullDTO PokemonFull2PokemonOutFullDTO(PokemonFull pokemon)
        {
            PokemonOutFullDTO pokemonDto = new PokemonOutFullDTO();
            pokemonDto.Nome = pokemon.name;
            foreach (var ability in pokemon.abilities)
            {
                pokemonDto.Abilities.Add(ability.ability.name);
            }
            foreach (var type in pokemon.types)
            {
                pokemonDto.Tipo.Add(type.type.name);
            }
            foreach (var move in pokemon.moves)
            {
                pokemonDto.Moves.Add(move.move.name);
            }
            return pokemonDto;
        }

        public UserDTO Usuario2UserDTO(Usuario user)
        {
            UserDTO userDto = new UserDTO();
            userDto.username = user.username;
            userDto.email = user.email;
            return userDto;
        }

        public IList<UserDTO> Usuario2UserDTO(IList<Usuario> users)
        {
            IList<UserDTO> usersDto = new List<UserDTO>();
            foreach(Usuario user in users)
            {
                usersDto.Add(Usuario2UserDTO(user));
            }
            return usersDto;
        }
    }
}
