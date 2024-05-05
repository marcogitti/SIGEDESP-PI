using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/unidade/consumidora")]
    [ApiController]
    public class UnidadeConsumidoraController : ControllerBase
    {
        private readonly IUnidadeConsumidoraService _unidadeConsumidoraService;

        public UnidadeConsumidoraController(IUnidadeConsumidoraService unidadeConsumidoraService)
        {
            _unidadeConsumidoraService = unidadeConsumidoraService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UnidadeConsumidoraDTO>>> BuscarTodosUnidadeConsumidora()
        {
            var unidadeConsumidoras = await _unidadeConsumidoraService.BuscarTodosUnidadeConsumidora();
            return Ok(unidadeConsumidoras);
        }

        [HttpGet("{id}", Name = "GetUnidadeConsumidora")]
        public async Task<ActionResult<UnidadeConsumidoraModel>> BuscarPorId(int id)
        {
            var unidadeConsumidora = await _unidadeConsumidoraService.BuscarPorId(id);
            if (unidadeConsumidora == null) return NotFound("Unidade Consumidora não encontrada");
            return Ok(unidadeConsumidora);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] UnidadeConsumidoraDTO unidadeConsumidoraDTO)
        {
            if (unidadeConsumidoraDTO is null) return BadRequest("dado inválido");
            await _unidadeConsumidoraService.Adicionar(unidadeConsumidoraDTO);
            return new CreatedAtRouteResult("GetUnidadeConsumidora", new { id = unidadeConsumidoraDTO.Id }, unidadeConsumidoraDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<UnidadeConsumidoraModel>> Atualizar([FromBody] UnidadeConsumidoraDTO unidadeConsumidoraDTO)
        {
            if (unidadeConsumidoraDTO is null) return BadRequest("dado inválido");
            await _unidadeConsumidoraService.Atualizar(unidadeConsumidoraDTO);
            return Ok(unidadeConsumidoraDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidadeConsumidoraModel>> Apagar(int id)
        {
            var unidadeConsumidoraDTO = await _unidadeConsumidoraService.BuscarPorId(id);
            if (unidadeConsumidoraDTO == null) return BadRequest("Unidade Consumidora não encontrada");
            await _unidadeConsumidoraService.Apagar(id);
            return Ok(unidadeConsumidoraDTO);
        }

    }
}