using api.DTO.Entities;
using api.Models;
using api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FornecedorDTO>>> BuscarTodosFornecedor()
        {
            var fornecedor = await _fornecedorService.BuscarTodosFornecedor();
            return Ok(fornecedor);
        }

        [HttpGet("{id}", Name = "GetFornecedor")]
        public async Task<ActionResult<FornecedorModel>> BuscarPorId(int id)
        {
            var fornecedor = await _fornecedorService.BuscarPorId(id);
            if (fornecedor == null) return NotFound("Fornecedor não encontrado");
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] FornecedorDTO fornecedorDTO)
        {
            if (fornecedorDTO is null) return BadRequest("dado inválido");
            await _fornecedorService.Adicionar(fornecedorDTO);
            return new CreatedAtRouteResult("GetFornecedor", new { id = fornecedorDTO.Id }, fornecedorDTO);
        }

        [HttpPut()]
        public async Task<ActionResult<FornecedorModel>> Atualizar([FromBody] FornecedorDTO fornecedorDTO)
        {
            if (fornecedorDTO is null) return BadRequest("dado inválido");
            await _fornecedorService.Atualizar(fornecedorDTO);
            return Ok(fornecedorDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FornecedorModel>> Apagar(int id)
        {
            var fornecedorDTO = await _fornecedorService.BuscarPorId(id);
            if (fornecedorDTO == null) return BadRequest("Fornecedor não encontrado");
            await _fornecedorService.Apagar(id);
            return Ok(fornecedorDTO);
        }

    }
}
