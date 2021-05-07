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

        private void Commit()
        {
            contexto.SaveChanges();
        }

        public void MudarNick(string email, string novoNick)
        {
            Usuario user = GetUserByEmail(email);
            user.SetUsername(novoNick);
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

        public IList<Usuario> ListarTreinadores()
        {
            var lista = contexto.user.ToList();
            if(lista.Count == 0)
            {
                throw new Exception("Não há treinadores cadastrados");
            }
            return lista;
        }
        public IList<Usuario> FindByUsername(string username)
        {
            IList<Usuario> userDesejado = contexto.user.Where(w => w.username == username).ToList();
            if(userDesejado.Count == 0)
            {
                throw new Exception($"Treinador {username} inexistente");
            }
            return userDesejado;
        }

        public Usuario GetUserByEmail(string email)
        {
            Usuario user = contexto.user.FirstOrDefault(u => u.email == email);
            //if (user == null)
            //{
            //    throw new Exception($"E-mail {email} não encontrado no banco de treinadores");
            //}
            return user;
        }
    }
}
