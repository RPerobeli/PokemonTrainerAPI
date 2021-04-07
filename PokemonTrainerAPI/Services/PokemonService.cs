using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Map.Interfaces;
using PokemonTrainerAPI.Repository.Interfaces;
using PokemonTrainerAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Services
{
    public class PokemonService : IPokemonService
    {
        private IUserRepository userRepository;
        private IUserService userService;
        private IPokemonRepository pkRepository;
        private IMapper mapper;

        public PokemonService(IUserService _userService, IUserRepository _userRepository, IPokemonRepository _pkRepository, IMapper _mapper)
        {
            userService = _userService;
            userRepository = _userRepository;
            pkRepository = _pkRepository;
            mapper = _mapper;
        }
        public bool AdicionarPokemon(string nome, string email)
        {
            if (userService.VerificarExistenciaEmailNoBanco(email))
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
        public IList<PokemonOutDTO> ListarPokemonsDoUser(string email)
        {
            Usuario user = userRepository.GetUserByEmail(email);
            IList<Pokemon> listaPokemons = pkRepository.ListarPokemons(user);
            IList<PokemonOutDTO> listaPokemonsSaida = mapper.Pokemon2PokemonOutDTO(listaPokemons);
            return listaPokemonsSaida;
        }
    }
    
}
