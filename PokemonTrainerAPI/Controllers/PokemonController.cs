using Microsoft.AspNetCore.Mvc;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class PokemonController : ControllerBase
    {
        private IPokemonService pkService;
        public PokemonController(IPokemonService _pkService)
        {
            pkService = _pkService;
        }
        /// <summary>
        /// Adicionar um pokemon ao time do usuario
        /// </summary>
        /// <param name="pokemonDTO"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso modificar username", Type = typeof(PokemonDTO))]
        [SwaggerResponse(statusCode: 404, description: "email não encontrado", Type = typeof(PokemonDTO))]
        [HttpPost]
        [Route("add")]
        public IActionResult AddPokemon(PokemonDTO pokemonDto)
        {
            try
            {
                pkService.AdicionarPokemon(pokemonDto.nome, pokemonDto.email);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Created("", pokemonDto);
        }
        /// <summary>
        /// Listar os pokemons de um usuário cadastrado.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Listar", Type = typeof(IList<PokemonOutDTO>))]
        [SwaggerResponse(statusCode: 404, description: "Não há pokemons ou não há treinador", Type = typeof(IList<PokemonOutDTO>))]
        [HttpGet]
        [Route("listaPorEmail/{email}")]
        public IActionResult ListarPokemons(string email)
        {
            IList<PokemonOutDTO> lista = new List<PokemonOutDTO>();
            try
            {
                lista = pkService.ListarPokemonsDoUser(email);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(lista);
        }

        /// <summary>
        /// Listar os pokemons de um usuário cadastrado com mais detalhes (tipos e habilidades passivas).
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Listar", Type = typeof(IList<PokemonOutDetailedDTO>))]
        [SwaggerResponse(statusCode: 404, description: "Não há pokemons ou não há treinador", Type = typeof(IList<PokemonOutDetailedDTO>))]
        [HttpGet]
        [Route("listaPorEmailDetalhado/{email}")]
        public IActionResult ListarPokemonsDetailsAsync(string email)
        {
            IList<PokemonOutDetailedDTO> lista = new List<PokemonOutDetailedDTO>();
            try
            {
                var task = pkService.ListarPokemonsDoUserDetalhado(email);
                lista = task.Result;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(lista);
        }

        /// <summary>
        /// Listar TODA a informação de um pokemon.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Listar", Type = typeof(IList<PokemonOutFullDTO>))]
        [SwaggerResponse(statusCode: 404, description: "Não há pokemons ou não há treinador", Type = typeof(IList<PokemonOutFullDTO>))]
        [HttpGet]
        [Route("{nome}")]
        public IActionResult PokemonsDetailsAsync(string nome)
        {
            PokemonOutFullDTO pokemon = new PokemonOutFullDTO();
            try
            {
                Task<PokemonOutFullDTO> task = pkService.PokemonDetalhado(nome);
                pokemon = task.Result;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(pokemon);
        }
    }
}
