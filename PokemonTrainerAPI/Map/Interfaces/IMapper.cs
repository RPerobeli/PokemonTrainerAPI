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
        NovoUserDTO Usuario2NovoUserDTO(Usuario user);
    }
}
