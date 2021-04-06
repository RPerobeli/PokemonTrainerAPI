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
        public NovoUserDTO Usuario2NovoUserDTO(Usuario user)
        {
            NovoUserDTO userDto = new NovoUserDTO();
            userDto.username = user.username;
            userDto.email = user.email;
            return userDto;
        }
    }
}
