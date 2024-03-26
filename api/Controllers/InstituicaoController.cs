using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _instituicaoService;

        public InstituicaoController(IInstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<instituicaoDTO>>> BuscarTodosInstituicao()
        {
            var instituicao = await _instituicaoService.BuscarTodosInstituicao();
            return Ok(instituicao);
        }

        [HttpGet("{id}", Name = "GetInstituicao")]
        public async Task<ActionResult<InstituicaoModel>> BuscarPorId(int id)
        {
            var instituicao = await _instituicaoService.BuscarPorId(id);
            if (instituicao == null) return NotFound("Instituicao não encontrado");
            return Ok(instituicao);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] InstituicaoDTO instituicaoDTO)
        {
            if (instituicaoDTO is null) return BadRequest("dado inválido");
            await _instituicaoService.Adicionar(instituicaoDTO);
            return new CreatedAtRouteResult("GetInstituicao", new { id = instituicaoDTO.Id }, instituicaoDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<InstituicaoModel>> Atualizar([FromBody] InstituicaoDTO instituicaoDTO)
        {
            if (instituicaoDTO is null) return BadRequest("dado inválido");
            await _InstituicaoService.Atualizar(instituicaoDTO);
            return Ok(instituicaoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InstituicaoModel>> Apagar(int id)
        {
            var instituicaoDTO = await _InstituicaoService.BuscarPorId(id);
            if (instituicaoDTO == null) return BadRequest("Instituicao não encontrado");
            await _instituicaoService.Apagar(id);
            return Ok(instituicaoDTO);
        }

    }
}
