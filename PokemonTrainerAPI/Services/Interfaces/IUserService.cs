using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Services.Interfaces
{
    public interface IUserService
    {
        bool AdicionarUsuario(UserDTO novoUser);
        bool MudarNick(string novoNick, string email);
        IList<Pokemon> ListarPokemonsDoUser(int id);

        IList<UserDTO> ListarTreinadores();
        IList<UserDTO> GetUserByUsername(string username);
    }
}
