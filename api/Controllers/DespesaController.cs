using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/despesa")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaService _despesaService;

        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DespesaDTO>>> BuscarTodosDespesa()
        {
            var despesa = await _despesaService.BuscarTodosDespesa();
            return Ok(despesa);
        }

        [HttpGet("{id}", Name = "GetDespesa")]
        public async Task<ActionResult<DespesaModel>> BuscarPorId(int id)
        {
            var despesa = await _despesaService.BuscarPorId(id);
            if (despesa == null) return NotFound("Despesa não encontrada");
            return Ok(despesa);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] DespesaDTO despesaDTO)
        {
            if (despesaDTO is null) return BadRequest("dado inválido");
            await _despesaService.Adicionar(despesaDTO);
            return new CreatedAtRouteResult("GetDespesa", new { id = despesaDTO.Id }, despesaDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<DespesaModel>> Atualizar([FromBody] DespesaDTO despesaDTO)
        {
            if (despesaDTO is null) return BadRequest("dado inválido");
            await _despesaService.Atualizar(despesaDTO);
            return Ok(despesaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DespesaModel>> Apagar(int id)
        {
            var despesaDTO = await _despesaService.BuscarPorId(id);
            if (despesaDTO == null) return BadRequest("Despesa não encontrado");
            await _despesaService.Apagar(id);
            return Ok(despesaDTO);
        }

    }
}
