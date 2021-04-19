using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Map.Interfaces;
using PokemonTrainerAPI.Repository.Interfaces;
using PokemonTrainerAPI.Services.Interfaces;
using System.Collections.Generic;

namespace PokemonTrainerAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IPokemonRepository pkRepository;
        private IMapper mapper;

        public UserService(IUserRepository _userRepository, IMapper _mapper, IPokemonRepository _pkRepository)
        {
            userRepository = _userRepository;
            mapper = _mapper;
            pkRepository = _pkRepository;
        }

        public bool AdicionarPokemon(string nome, string email)
        {
            if (VerificarExistenciaEmailNoBanco(email))
            {
                Pokemon pokemon = new Pokemon();
                pokemon.nome = nome;
                Usuario user = userRepository.GetUserByEmail(email);
                pokemon.idTrainer = user.id;
                pkRepository.InserirPokemon(pokemon);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AdicionarUsuario(UserDTO novoUser)
        {
            Usuario user = new Usuario();
            if(!VerificarExistenciaEmailNoBanco(novoUser.email))
            {
                user.SetEmail(novoUser.email);
                user.SetUsername(novoUser.username);
                userRepository.InserirUser(user);
            }
        }
        public IList<UserDTO> GetUserByUsername(string username)
        {
            IList<Usuario> user = userRepository.FindByUsername(username);
            IList<UserDTO> userDto = mapper.Usuario2UserDTO(user);
            return userDto;
        }
        public IList<UserDTO> ListarTreinadores()
        {
            IList<Usuario> lista = userRepository.ListarTreinadores();
            IList<UserDTO> listaSaida = mapper.Usuario2UserDTO(lista);
            return listaSaida;
        }

        public void MudarNick(string novoNick, string email)
        {
            userRepository.MudarNick(email, novoNick);
        }
        public bool VerificarExistenciaEmailNoBanco(string email)
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
