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
        void AdicionarUsuario(UserDTO novoUser);
        void MudarNick(string novoNick, string email);
        IList<UserDTO> ListarTreinadores();
        IList<UserDTO> GetUserByUsername(string username);
        bool VerificarExistenciaEmailNoBanco(string email);
    }
}
