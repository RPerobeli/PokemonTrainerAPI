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
    }
}
