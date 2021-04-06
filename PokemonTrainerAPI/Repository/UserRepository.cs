using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.Repository.Interfaces;
using System;
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

        public bool MudarNick(string email, string novoNick)
        {
            Usuario user = contexto.user.FirstOrDefault(u => u.email == email);
            if(user == null)
            {
                return false;
            }
            else
            {
                user.SetUsername(novoNick);
                //contexto.Update(user);
                Commit();
                return true;
            }
            
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

        public IList<Usuario> ListarTreinadores()
        {
            var lista = contexto.user.Select(s => new Usuario
            {
                id = s.id,
                username = s.username,
                email = s.email,
            }).ToList();
            return lista;
        }
        public IList<Usuario> FindByUsername(string username)
        {
            IList<Usuario> userDesejado = contexto.user.Select(i => new Usuario
            {
                id = i.id,
                username = i.username,
                email = i.email
            }).Where(w => w.username == username).ToList();

            return userDesejado;
        }

        public Usuario GetUserByEmail(string email)
        {
            Usuario user = contexto.user.FirstOrDefault(u => u.email == email);
            return user;
        }
    }
}
