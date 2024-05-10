using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/tipo/usuario")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _tipoUsuarioService;

        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            _tipoUsuarioService = tipoUsuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoUsuarioDTO>>> BuscarTodosTipoUsuario()
        {
            var tipoUsuario = await _tipoUsuarioService.BuscarTodosTipoUsuario();
            return Ok(tipoUsuario);
        }

        [HttpGet("{id}", Name = "GetTipoUsuario")]
        public async Task<ActionResult<TipoUsuarioModel>> BuscarPorId(int id)
        {
            var tipoUsuario = await _tipoUsuarioService.BuscarPorId(id);
            if (tipoUsuario == null) return NotFound("Tipo Usuário não encontrada");
            return Ok(tipoUsuario);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] TipoUsuarioDTO tipoUsuarioDTO)
        {
            if (tipoUsuarioDTO is null) return BadRequest("dado inválido");
            await _tipoUsuarioService.Adicionar(tipoUsuarioDTO);
            return new CreatedAtRouteResult("GetTipoUsuario", new { id = tipoUsuarioDTO.Id }, tipoUsuarioDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<TipoUsuarioModel>> Atualizar([FromBody] TipoUsuarioDTO tipoUsuarioDTO)
        {
            if (tipoUsuarioDTO is null) return BadRequest("dado inválido");
            await _tipoUsuarioService.Atualizar(tipoUsuarioDTO);
            return Ok(tipoUsuarioDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoUsuarioModel>> Apagar(int id)
        {
            var tipoUsuarioDTO = await _tipoUsuarioService.BuscarPorId(id);
            if (tipoUsuarioDTO == null) return BadRequest("Tipo Usuário não encontrada");
            await _tipoUsuarioService.Apagar(id);
            return Ok(tipoUsuarioDTO);
        }

    }
}
