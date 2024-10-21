using api.Data;
using api.DTO.Entities;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/tipo/despesa")]
public class TipoDespesaController : ControllerBase
{
    private readonly SigedespDBContex _context;

    public TipoDespesaController(SigedespDBContex context)
    {
        _context = context;
    }

    // Método para buscar todas os tipo despesas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> BuscarTodosTipoDespesa()
    {
        var tipodespesas = await _context.TipoDespesa
            .Select(d => new
            {
                Id = d.Id,
                Descricao = d.Descricao,
                SolicitaUC = d.SolicitaUC,
                UnidadeMedida = new
                {
                    Id = d.UnidadeMedida.Id,
                    Descricao = d.UnidadeMedida.Descricao
                }
            })
            .ToListAsync();

        return Ok(tipodespesas);
    }

    // Método para buscar tipo despesa por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> BuscarPorId(int id)
    {
        var tipodespesa = await _context.TipoDespesa
            .Where(d => d.Id == id)
            .Select(d => new
            {
                Id = d.Id,
                Descricao = d.Descricao,
                SolicitaUC = d.SolicitaUC,
                UnidadeMedida = new
                {
                    Id = d.UnidadeMedida.Id,
                    Descricao = d.UnidadeMedida.Descricao
                }
            })
            .FirstOrDefaultAsync();

        if (tipodespesa == null)
            return NotFound("Tipo Despesa não encontrada");

        return Ok(tipodespesa);
    }

    // Método para adicionar novo tipo despesa
    [HttpPost]
    public async Task<ActionResult> Cadastrar([FromBody] TipoDespesaAdicionarAtualizarDTO tipodespesaDto)
    {
        if (tipodespesaDto == null)
            return BadRequest("Dados inválidos");

        var tipodespesa = new TipoDespesaModel
        {
            Descricao = tipodespesaDto.Descricao,
            SolicitaUC = tipodespesaDto.SolicitaUC,
            IdUnidadeMedida = tipodespesaDto.IdUnidadeMedida
        };

        _context.TipoDespesa.Add(tipodespesa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = tipodespesa.Id }, tipodespesa);
    }

    // Método para atualizar tipo despesa existente
    [HttpPut()]
    public async Task<ActionResult> Atualizar([FromBody] TipoDespesaAdicionarAtualizarDTO tipodespesaAtualizada)
    {
        if (tipodespesaAtualizada == null || tipodespesaAtualizada.Id != tipodespesaAtualizada.Id)
            return BadRequest("Dados inválidos");

        var tipodespesaExistente = await _context.TipoDespesa.FindAsync(tipodespesaAtualizada.Id);

        if (tipodespesaExistente == null)
            return NotFound("Tipo Despesa não encontrada");

        _context.Entry(tipodespesaExistente).CurrentValues.SetValues(tipodespesaAtualizada);
        await _context.SaveChangesAsync();

        return Ok(tipodespesaAtualizada);
    }

    // Método para deletar tipo despesa
    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> Apagar(int id)
    {
        var tipodespesa = await _context.TipoDespesa.FindAsync(id);

        if (tipodespesa == null)
            return NotFound("Tipo Despesa não encontrada");

        _context.TipoDespesa.Remove(tipodespesa);
        await _context.SaveChangesAsync();

        var tipodespesaRemovida = new TipoDespesaDTO
        {
            Id = tipodespesa.Id,
            Descricao = tipodespesa.Descricao,
            UnidadeMedida = new UnidadeMedidaDTO
            {
                Id = tipodespesa.UnidadeMedida.Id,
                Descricao = tipodespesa.UnidadeMedida.Descricao
            }
        };

        return Ok(tipodespesaRemovida);
    }
}
