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
