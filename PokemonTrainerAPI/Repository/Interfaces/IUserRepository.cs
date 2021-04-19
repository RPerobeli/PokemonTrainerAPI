using PokemonTrainerAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        void InserirUser(Usuario user);
        IList<Usuario> ListarTreinadores();
        void MudarNick(string email, string NovoNick);
        void DeleteAll();
        IList<Usuario> FindByUsername(string username);
        Usuario GetUserByEmail(string email);
    }
}
