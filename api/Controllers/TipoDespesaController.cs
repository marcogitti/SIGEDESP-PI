using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/tipo/despesa")]
    [ApiController]
    public class TipoDespesaController : ControllerBase
    {
        private readonly ITipoDespesaService _tipoDespesaService;

        public TipoDespesaController(ITipoDespesaService tipoDespesaService)
        {
            _tipoDespesaService = tipoDespesaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDespesaDTO>>> BuscarTodosTipoDespesa()
        {
            var tipoDespesas = await _tipoDespesaService.BuscarTodosTipoDespesa();
            return Ok(tipoDespesas);
        }

        [HttpGet("{id}", Name = "GetTipoDespesa")]
        public async Task<ActionResult<TipoDespesaModel>> BuscarPorId(int id)
        {
            var tipoDespesa = await _tipoDespesaService.BuscarPorId(id);
            if (tipoDespesa == null) return NotFound("Tipo Despesa não encontrada");
            return Ok(tipoDespesa);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] TipoDespesaDTO tipoDespesaDTO)
        {
            if (tipoDespesaDTO is null) return BadRequest("dado inválido");
            await _tipoDespesaService.Adicionar(tipoDespesaDTO);
            return new CreatedAtRouteResult("GetTipoDespesa", new { id = tipoDespesaDTO.Id }, tipoDespesaDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<TipoDespesaModel>> Atualizar([FromBody] TipoDespesaDTO tipoDespesaDTO)
        {
            if (tipoDespesaDTO is null) return BadRequest("dado inválido");
            await _tipoDespesaService.Atualizar(tipoDespesaDTO);
            return Ok(tipoDespesaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDespesaModel>> Apagar(int id)
        {
            var tipoDespesaDTO = await _tipoDespesaService.BuscarPorId(id);
            if(tipoDespesaDTO == null) return BadRequest("Tipo Despesa não encontrada");
            await _tipoDespesaService.Apagar(id);
            return Ok(tipoDespesaDTO);
        }

    }
}
