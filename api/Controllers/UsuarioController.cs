using api.Authentication;
using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> BuscarTodosUsuario()
        {
            var usuario = await _usuarioService.BuscarTodosUsuario();
            return Ok(usuario);
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            var usuario = await _usuarioService.BuscarPorId(id);
            if (usuario == null) return NotFound("Usuário não encontrado");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO is null) return BadRequest("dado inválido");
            await _usuarioService.Adicionar(usuarioDTO);
            return new CreatedAtRouteResult("GetUsuario", new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            if (login is null) return BadRequest("dado inválido");

            var usuarioDTO = await _usuarioService.Login(login);
            if (usuarioDTO is not null)
            {
                var token = new TokenAcess();
                return Ok(token.GenerateToken(usuarioDTO.Email));
            }

            return Unauthorized("email ou senha incorretos");
        }

        [HttpPost("validation")]
        public async Task<ActionResult> Validate([FromBody] TokenAcess tokenAcess)
        {
            if (tokenAcess is null) return BadRequest("dado inválido");

            if (tokenAcess.IsTokenExpired(tokenAcess.Token))
            {
                return Unauthorized("token expirado");
            }

            var email = tokenAcess.GetEmailFromToken(tokenAcess.Token);
            if (!string.IsNullOrEmpty(email))
            {
                var user = await _usuarioService.BuscarPorEmail(email);

                if (user is not null) return Ok(true);
                else return Unauthorized(false);
            }

            return Unauthorized(false);
        }

        [HttpPut()]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO is null) return BadRequest("dado inválido");
            await _usuarioService.Atualizar(usuarioDTO);
            return Ok(usuarioDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            var usuarioDTO = await _usuarioService.BuscarPorId(id);
            if (usuarioDTO == null) return BadRequest("Usuário não encontrado");
            await _usuarioService.Apagar(id);
            return Ok(usuarioDTO);
        }

    }
}
