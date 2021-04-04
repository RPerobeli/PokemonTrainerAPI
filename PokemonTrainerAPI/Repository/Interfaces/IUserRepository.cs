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
        void Commit();
        IList<Pokemon> ListarPokemons(int idUser);
        void MudarNick(int id, string NovoNick);
        void DeleteAll();
    }
}
