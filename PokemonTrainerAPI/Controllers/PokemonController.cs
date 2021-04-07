using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerAPI.Controllers
{
    [Route("api/[controller]")]
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
            if (pokemonDto == null)
            {
                return BadRequest("Houve um erro ao tentar adicionar um pokemon.");
            }
            if (!pkService.AdicionarPokemon(pokemonDto.nome, pokemonDto.email))
            {
                return NotFound("O email procurado não existe no banco");
            }
            return Created("", pokemonDto);
        }
        /// <summary>
        /// Listar os pokemons de um usuário cadastrado.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Listar", Type = typeof(IList<UserDTO>))]
        [HttpGet]
        [Route("listaPorEmail/{email}")]
        public IActionResult ListarTreinadores(string email)
        {
            IList<PokemonOutDTO> lista = pkService.ListarPokemonsDoUser(email);
            return Ok(lista);
        }
    }
}
