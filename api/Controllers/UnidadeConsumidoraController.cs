using api.Data;
using api.DTO.Entities;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/unidade/consumidora")]
public class UnidadeConsumidoraController : ControllerBase
{
    private readonly SigedespDBContex _context;

    public UnidadeConsumidoraController(SigedespDBContex context)
    {
        _context = context;
    }

    // Método para buscar todas as unidades consumidoras
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> BuscarTodosUnidadeConsumidora()
    {
        var unidadesConsumidoras = await _context.UnidadeConsumidora
            .Select(d => new
            {
                Id = d.Id,
                CodigoUC = d.CodigoUC,
                Fornecedor = new
                {
                    Id = d.Fornecedor.Id,
                    NomeFantasia = d.Fornecedor.NomeFantasia
                },
                Instituicao = new
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
            })
            .ToListAsync();

        return Ok(unidadesConsumidoras);
    }

    // Método para buscar unidade consumidora por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> BuscarPorId(int id)
    {
        var unidadesConsumidoras = await _context.UnidadeConsumidora
            .Where(d => d.Id == id)
            .Select(d => new
            {
                Id = d.Id,
                CodigoUC = d.CodigoUC,
                Fornecedor = new
                {
                    Id = d.Fornecedor.Id,
                    NomeFantasia = d.Fornecedor.NomeFantasia
                },
                Instituicao = new
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
            })
            .FirstOrDefaultAsync();

        if (unidadesConsumidoras == null)
            return NotFound("Unidade Consumidora não encontrada");

        return Ok(unidadesConsumidoras);
    }

    // Método para adicionar nova unidade consumidora
    [HttpPost]
    public async Task<ActionResult> Cadastrar([FromBody] UnidadeConsumidoraAdicionarAtualizarDTO unidadeConsumidoraDto)
    {
        if (unidadeConsumidoraDto == null)
            return BadRequest("Dados inválidos");

        var unidadeConsumidora = new UnidadeConsumidoraModel
        {
            CodigoUC = unidadeConsumidoraDto.CodigoUC,
            IdFornecedor = unidadeConsumidoraDto.IdFornecedor,
            IdInstituicao = unidadeConsumidoraDto.IdInstituicao
        };

        _context.UnidadeConsumidora.Add(unidadeConsumidora);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = unidadeConsumidora.Id }, unidadeConsumidora);
    }

    // Método para atualizar unidade consumidora existente
    [HttpPut()]
    public async Task<ActionResult> Atualizar([FromBody] UnidadeConsumidoraAdicionarAtualizarDTO unidadeconsumidoraAtualizada)
    {
        if (unidadeconsumidoraAtualizada == null || unidadeconsumidoraAtualizada.Id != unidadeconsumidoraAtualizada.Id)
            return BadRequest("Dados inválidos");

        var unidadeconsumidoraExistente = await _context.UnidadeConsumidora.FindAsync(unidadeconsumidoraAtualizada.Id);

        if (unidadeconsumidoraExistente == null)
            return NotFound("Unidade Consumidora não encontrada");

        _context.Entry(unidadeconsumidoraExistente).CurrentValues.SetValues(unidadeconsumidoraAtualizada);
        await _context.SaveChangesAsync();

        return Ok(unidadeconsumidoraAtualizada);
    }

    // Método para deletar unidade consumidora
    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> Apagar(int id)
    {
        var unidadeConsumidora = await _context.UnidadeConsumidora.FindAsync(id);

        if (unidadeConsumidora == null)
            return NotFound("Unidade Consumidora não encontrada");

        _context.UnidadeConsumidora.Remove(unidadeConsumidora);
        await _context.SaveChangesAsync();

        var unidadeconsumidoraRemovida = new UnidadeConsumidoraDTO
        {
            Id = unidadeConsumidora.Id,
            CodigoUC = unidadeConsumidora.CodigoUC,
            Fornecedor = new FornecedorDTO
            {
                Id = unidadeConsumidora.Fornecedor.Id,
                NomeFantasia = unidadeConsumidora.Fornecedor.NomeFantasia
            },
            Instituicao = new InstituicaoDTO
            {
                Id = unidadeConsumidora.Instituicao.Id,
                Nome = unidadeConsumidora.Instituicao.Nome
            },
        };

        return Ok(unidadeconsumidoraRemovida);
    }
}
