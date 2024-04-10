using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/tipoinstituicao")]
    [ApiController]
    public class TipoInstituicaoController : ControllerBase
    {
        private readonly ITipoInstituicaoService _tipoInstituicaoService;

        public TipoInstituicaoController(ITipoInstituicaoService tipoInstituicaoService)
        {
            _tipoInstituicaoService = tipoInstituicaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoInstituicaoDTO>>> BuscarTodosTipoInstituicao()
        {
            var tipoInstituicaos = await _tipoInstituicaoService.BuscarTodosTipoInstituicao();
            return Ok(tipoInstituicaos);
        }

        [HttpGet("{id}", Name = "GetTipoInstituicao")]
        public async Task<ActionResult<TipoInstituicaoModel>> BuscarPorId(int id)
        {
            var tipoInstituicao = await _tipoInstituicaoService.BuscarPorId(id);
            if (tipoInstituicao == null) return NotFound("Tipo Instituicao não encontrada");
            return Ok(tipoInstituicao);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] TipoInstituicaoDTO tipoInstituicaoDTO)
        {
            if (tipoInstituicaoDTO is null) return BadRequest("dado inválido");
            await _tipoInstituicaoService.Adicionar(tipoInstituicaoDTO);
            return new CreatedAtRouteResult("GetTipoInstituicao", new { id = tipoInstituicaoDTO.Id }, tipoInstituicaoDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<TipoInstituicaoModel>> Atualizar([FromBody] TipoInstituicaoDTO tipoInstituicaoDTO)
        {
            if (tipoInstituicaoDTO is null) return BadRequest("dado inválido");
            await _tipoInstituicaoService.Atualizar(tipoInstituicaoDTO);
            return Ok(tipoInstituicaoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoInstituicaoModel>> Apagar(int id)
        {
            var tipoInstituicaoDTO = await _tipoInstituicaoService.BuscarPorId(id);
            if (tipoInstituicaoDTO == null) return BadRequest("Tipo Instituicao não encontrada");
            await _tipoInstituicaoService.Apagar(id);
            return Ok(tipoInstituicaoDTO);
        }

    }
}