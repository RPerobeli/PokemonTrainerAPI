using PokemonTrainerAPI.Domain;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Map.Interfaces;
using PokemonTrainerAPI.Repository.Interfaces;
using PokemonTrainerAPI.Services.Client;
using PokemonTrainerAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Services
{
    public class PokemonService : IPokemonService
    {
        private IUserRepository userRepository;
        private IUserService userService;
        private IPokemonRepository pkRepository;
        private IMapper mapper;
        private PokemonClient Cliente = new PokemonClient();

        public PokemonService(IUserService _userService, IUserRepository _userRepository, IPokemonRepository _pkRepository, IMapper _mapper)
        {
            userService = _userService;
            userRepository = _userRepository;
            pkRepository = _pkRepository;
            mapper = _mapper;
        }
        public void AdicionarPokemon(string nome, string email)
        {
            if (userService.VerificarExistenciaEmailNoBanco(email))
            {
                Pokemon pokemon = new Pokemon();
                pokemon.nome = nome;
                //ToDo: chama pokeAPI para instanciar restante dos atributos
                Usuario user = userRepository.GetUserByEmail(email);
                pokemon.idTrainer = user.id;
                pkRepository.InserirPokemon(pokemon);
            }
        }
        public IList<PokemonOutDTO> ListarPokemonsDoUser(string email)
        {
            Usuario user = userRepository.GetUserByEmail(email);
            IList<Pokemon> listaPokemons = pkRepository.ListarPokemons(user);
            IList<PokemonOutDTO> listaPokemonsSaida = mapper.Pokemon2PokemonOutDTO(listaPokemons);
            return listaPokemonsSaida;
        }

        public async Task<IList<PokemonOutDetailedDTO>> ListarPokemonsDoUserDetalhado(string email)
        {
            Usuario user = userRepository.GetUserByEmail(email);
            IList<Pokemon> listaPokemons = pkRepository.ListarPokemons(user);

            // consumir a api para cada pokemon in lista pokemons
            var listaPokemonsFull = await GetInfoPokeAPI(listaPokemons);
            //Mapear para a saída da API pkTrainer
            IList<PokemonOutDetailedDTO> listaPokemonsSaida = mapper.PokemonFull2PokemonOutDetailedDTO(listaPokemonsFull);
            return listaPokemonsSaida;
        }

        public async Task<PokemonOutFullDTO> PokemonDetalhado(string nome)
        {
            var pokemonFull = await GetInfoPokeAPI(nome);
            PokemonOutFullDTO pokemonSaida = mapper.PokemonFull2PokemonOutFullDTO(pokemonFull);
            return pokemonSaida;
        }
        private async Task<IList<PokemonFull>> GetInfoPokeAPI(IList<Pokemon> listaPokemons)
        {
            List<PokemonFull> listaPokemonFull = new List<PokemonFull>();
            foreach (var p in listaPokemons)
            {
                PokemonFull pokemonTask = await GetInfoPokeAPI(p.nome.ToLower());
                listaPokemonFull.Add(pokemonTask);
            }
            return listaPokemonFull;
        }
        private async Task<PokemonFull> GetInfoPokeAPI(string pokemonName)
        {
            PokemonFull pokemonTask = await Cliente.GetPokemonAsync(pokemonName.ToLower());
            return pokemonTask;
        }
    }
    
}
