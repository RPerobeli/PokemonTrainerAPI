using Microsoft.EntityFrameworkCore;
using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainerAPI.Repository
{
    public class UserRepository : IUserRepository 
    {
        private PkTrainerContext contexto;
        public UserRepository(PkTrainerContext context)
        {
            contexto  = context;
        }
        public void InserirUser(Usuario user)
        {
            contexto.user.Add(user);
            Commit();
        }

        public void Commit()
        {
            contexto.SaveChanges();
        }

        public IList<Pokemon> ListarPokemons(int idUser)
        {

            IList<Pokemon> listaPokemons= contexto.pokemon.Include(i => i.nome).Where(w => w.idTrainer == idUser).ToList();
            return listaPokemons;
        }

        public void MudarNick(int id, string novoNick)
        {
            Usuario user = contexto.user.FirstOrDefault(u => u.id == id);
            user.SetUsername(novoNick);
            //contexto.Update(user);
            Commit();
        }
        public void DeleteAll()
        {
            var users = from u in contexto.user select u;
            foreach( var user in users)
            {
                contexto.user.Remove(user);
            }
            Commit();
        }
    }
}
