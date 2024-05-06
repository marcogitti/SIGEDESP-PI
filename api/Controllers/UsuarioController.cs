using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
