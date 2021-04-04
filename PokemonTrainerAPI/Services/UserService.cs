using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Repository.Interfaces;
using PokemonTrainerAPI.Services.Interfaces;
using System.Collections.Generic;

namespace PokemonTrainerAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public void AdicionarUsuario(NovoUserDTO novoUser)
        {
            //Todo: Validar o novo usuario
            Usuario user = new Usuario();
            user.SetEmail(novoUser.email);
            user.SetUsername(novoUser.username);
            userRepository.InserirUser(user);
        }

        public IList<Pokemon> ListarPokemonsDoUser(int id)
        {
            IList<Pokemon> listaPokemons = userRepository.ListarPokemons(id);
            return listaPokemons;
        }

        public void MudarNick(string novoNick, int id)
        {
            userRepository.MudarNick(id, novoNick);
        }
    }
}
