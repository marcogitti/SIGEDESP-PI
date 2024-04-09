using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/secretaria")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ISecretariaService _secretariaService;

        public SecretariaController(ISecretariaService secretariaService)
        {
            _secretariaService = secretariaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SecretariaDTO>>> BuscarTodosSecretaria()
        {
            var secretaria = await _secretariaService.BuscarTodosSecretaria();
            return Ok(secretaria);
        }

        [HttpGet("{id}", Name = "GetSecretaria")]
        public async Task<ActionResult<SecretariaModel>> BuscarPorId(int id)
        {
            var secretaria = await _secretariaService.BuscarPorId(id);
            if (secretaria == null) return NotFound("Secretaria não encontrada");
            return Ok(secretaria);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] SecretariaDTO secretariaDTO)
        {
            if (secretariaDTO is null) return BadRequest("dado inválido");
            await _secretariaService.Adicionar(secretariaDTO);
            return new CreatedAtRouteResult("GetSecretaria", new { id = secretariaDTO.Id }, secretariaDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<SecretariaModel>> Atualizar([FromBody] SecretariaDTO secretariaDTO)
        {
            if (secretariaDTO is null) return BadRequest("dado inválido");
            await _secretariaService.Atualizar(secretariaDTO);
            return Ok(secretariaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SecretariaModel>> Apagar(int id)
        {
            var secretariaDTO = await _secretariaService.BuscarPorId(id);
            if (secretariaDTO == null) return BadRequest("Secretaria não encontrada");
            await _secretariaService.Apagar(id);
            return Ok(secretariaDTO);
        }

    }
}
