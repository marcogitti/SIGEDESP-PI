using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using api.Services.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/orcamento")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly IOrcamentoService _orcamentoService;

        public OrcamentoController(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrcamentoDTO>>> BuscarTodosOrcamento()
        {
            var orcamento = await _orcamentoService.BuscarTodosOrcamento();
            return Ok(orcamento);
        }

        [HttpGet("{id}", Name = "GetOrcamento")]
        public async Task<ActionResult<OrcamentoModel>> BuscarPorId(int id)
        {
            var orcamento = await _orcamentoService.BuscarPorId(id);
            if (orcamento == null) return NotFound("Orçamento não encontrado");
            return Ok(orcamento);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] OrcamentoDTO orcamentoDTO)
        {
            if (orcamentoDTO is null) return BadRequest("dado inválido");
            await _orcamentoService.Adicionar(orcamentoDTO);
            return new CreatedAtRouteResult("GetOrcamento", new { id = orcamentoDTO.Id }, orcamentoDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<OrcamentoModel>> Atualizar([FromBody] OrcamentoDTO orcamentoDTO)
        {
            if (orcamentoDTO is null) return BadRequest("dado inválido");
            await _orcamentoService.Atualizar(orcamentoDTO);
            return Ok(orcamentoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrcamentoModel>> Apagar(int id)
        {
            var orcamentoDTO = await _orcamentoService.BuscarPorId(id);
            if (orcamentoDTO == null) return BadRequest("Orçamento não encontrado");
            await _orcamentoService.Apagar(id);
            return Ok(orcamentoDTO);
        }

    }
}
