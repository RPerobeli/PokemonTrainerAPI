using PokemonTrainerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.DTO
{
    public class UserDTO
    {
        public string username { get; set; }
        public string email { get; set; }

        public List<PokemonDTO> listaDePokemons { get; set;}
    }
}
