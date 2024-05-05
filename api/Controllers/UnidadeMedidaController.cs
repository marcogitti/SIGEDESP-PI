using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/unidade/medida")]
    [ApiController]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaService _unidadeMedidaService;

        public UnidadeMedidaController(IUnidadeMedidaService UnidadeMedidaService)
        {
            _unidadeMedidaService = UnidadeMedidaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UnidadeMedidaDTO>>> BuscarTodosUnidadeMedida()
        {
            var unidadeMedidas = await _unidadeMedidaService.BuscarTodosUnidadeMedida();
            return Ok(unidadeMedidas);
        }

        [HttpGet("{id}", Name = "GetUnidadeMedida")]
        public async Task<ActionResult<UnidadeMedidaModel>> BuscarPorId(int id)
        {
            var unidadeMedida = await _unidadeMedidaService.BuscarPorId(id);
            if (unidadeMedida == null) return NotFound("Unidade de Medida não encontrada");
            return Ok(unidadeMedida);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] UnidadeMedidaDTO unidadeMedidaDTO)
        {
            if (unidadeMedidaDTO is null) return BadRequest("dado inválido");
            await _unidadeMedidaService.Adicionar(unidadeMedidaDTO);
            return new CreatedAtRouteResult("GetUnidadeMedida", new { id = unidadeMedidaDTO.Id }, unidadeMedidaDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<UnidadeMedidaModel>> Atualizar([FromBody] UnidadeMedidaDTO unidadeMedidaDTO)
        {
            if (unidadeMedidaDTO is null) return BadRequest("dado inválido");
            await _unidadeMedidaService.Atualizar(unidadeMedidaDTO);
            return Ok(unidadeMedidaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidadeMedidaModel>> Apagar(int id)
        {
            var unidadeMedidaDTO = await _unidadeMedidaService.BuscarPorId(id);
            if (unidadeMedidaDTO == null) return BadRequest("Unidade de Medida não encontrada");
            await _unidadeMedidaService.Apagar(id);
            return Ok(unidadeMedidaDTO);
        }

    }
}
