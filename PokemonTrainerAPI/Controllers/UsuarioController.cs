using Microsoft.AspNetCore.Mvc;
using PokemonTrainerAPI.DTO;
using PokemonTrainerAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace PokemonTrainerAPI.Controllers
{
    [Route("[controller]")]
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
            try
            {
                userService.AdicionarUsuario(novoUserDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("", novoUserDto);
        }
        /// <summary>
        /// Listar os treinadores cadastrados
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Listar", Type = typeof(IList<UserDTO>))]
        [HttpGet]
        [Route("listarTreinadores")]
        public IActionResult ListarTreinadores()
        {
            IList<UserDTO> lista = new List<UserDTO>();
            try
            {
                lista = userService.ListarTreinadores();
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(lista);
        }

        /// <summary>
        /// Listar os treinadores a partir do username
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso recuperar usuario", Type = typeof(IList<UserDTO>))]
        [SwaggerResponse(statusCode: 404, description: "usuário não encontrado", Type = typeof(IList<UserDTO>))]
        [HttpGet]
        [Route("{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            IList<UserDTO> userDesejado = new List<UserDTO>();
            try
            {
                userDesejado = userService.GetUserByUsername(username);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
            return Ok(userDesejado);
        }

        /// <summary>
        /// Modificar o username de um usuario
        /// </summary>
        /// <param name="novoNickDto"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 204, description: "Sucesso modificar username", Type = typeof(UserDTO))]
        [SwaggerResponse(statusCode: 404, description: "email não encontrado", Type = typeof(UserDTO))]
        [HttpPut]
        [Route("nickname")]
        public IActionResult ModificarUsername(UserDTO novoNickDto)
        {
            try
            {
                userService.MudarNick(novoNickDto.username, novoNickDto.email);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Accepted(novoNickDto);
        }

    }
}
