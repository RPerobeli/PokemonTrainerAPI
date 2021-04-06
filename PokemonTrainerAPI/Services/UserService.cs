﻿using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Map;
using PokemonTrainerAPI.Map.Interfaces;
using PokemonTrainerAPI.Repository.Interfaces;
using PokemonTrainerAPI.Services.Interfaces;
using System.Collections.Generic;

namespace PokemonTrainerAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapper mapper;

        public UserService(IUserRepository _userRepository, IMapper _mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
        }
        public bool AdicionarUsuario(UserDTO novoUser)
        {
            Usuario user = new Usuario();
            if(!VerificarExistenciaEmailNoBanco(novoUser.email))
            {
                user.SetEmail(novoUser.email);
                user.SetUsername(novoUser.username);
                userRepository.InserirUser(user);
                return true;
            }else
            {
                return false;
            }  
        }
        public IList<UserDTO> GetUserByUsername(string username)
        {
            IList<Usuario> user = userRepository.FindByUsername(username);
            IList<UserDTO> userDto = mapper.Usuario2UserDTO(user);
            return userDto;
        }

        public IList<Pokemon> ListarPokemonsDoUser(int id)
        {
            IList<Pokemon> listaPokemons = userRepository.ListarPokemons(id);
            return listaPokemons;
        }

        public IList<UserDTO> ListarTreinadores()
        {
            IList<Usuario> lista = userRepository.ListarTreinadores();
            IList<UserDTO> listaSaida = mapper.Usuario2UserDTO(lista);
            return listaSaida;
        }

        public bool MudarNick(string novoNick, string email)
        {
            bool flag = userRepository.MudarNick(email, novoNick);
            return flag;
        }
        private bool VerificarExistenciaEmailNoBanco(string email)
        {
            Usuario user = userRepository.GetUserByEmail(email);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
