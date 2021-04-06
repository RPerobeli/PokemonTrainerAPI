using Microsoft.AspNetCore.Mvc;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace PokemonTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUserService userService;
        private IPokemonService pkService;
        public UsuarioController(IUserService _userService, IPokemonService _pkService)
        {
            userService = _userService;
            pkService = _pkService;
        }
        /// <summary>
        /// Registrar um usuário
        /// </summary>
        /// <param name="novoUserDto"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Registrar", Type = typeof(UserDTO))]
        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(UserDTO novoUserDto)
        {
            if (novoUserDto == null)
            {
                return BadRequest("Houve um erro ao tentar registrar");
            }
            userService.AdicionarUsuario(novoUserDto);
            return Created("", novoUserDto);
        }
        /// <summary>
        /// Listar os treinadores cadastrados
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Listar", Type = typeof(UserDTO))]
        [HttpGet]
        [Route("listarTreinadores")]
        public IActionResult ListarTreinadores()
        {
            IList<UserDTO> lista = userService.ListarTreinadores();
            return Ok(lista);
        }

        /// <summary>
        /// Listar os treinadores cadastrados
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso recuperar usuario", Type = typeof(UserDTO))]
        [HttpGet]
        [Route("{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            IList<UserDTO> userDesejado = userService.GetUserByUsername(username);
            return Ok(userDesejado);
        }

    }
}
