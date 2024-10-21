using api.Data;
using api.DTO.Entities;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/orcamento")]
public class OrcamentoController : ControllerBase
{
    private readonly SigedespDBContex _context;

    public OrcamentoController(SigedespDBContex context)
    {
        _context = context;
    }

    // Método para buscar todas os orçamentos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> BuscarTodosOrcamento()
    {
        var orcamentos = await _context.Orcamento
            .Select(d => new
            {
                Id = d.Id,
                AnoOrcamento = d.AnoOrcamento,
                ValorOrcamento = d.ValorOrcamento,
                Instituicao = new
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
                TipoDespesa = new
                {
                    Id = d.TipoDespesa.Id,
                    Descricao = d.TipoDespesa.Descricao
                }
            })
            .ToListAsync();

        return Ok(orcamentos);
    }

    // Método para buscar orçamento por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> BuscarPorId(int id)
    {
        var orcamento = await _context.Orcamento
            .Where(d => d.Id == id)
            .Select(d => new
            {
                Id = d.Id,
                AnoOrcamento = d.AnoOrcamento,
                ValorOrcamento = d.ValorOrcamento,
                Instituicao = new
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
                TipoDespesa = new
                {
                    Id = d.TipoDespesa.Id,
                    Descricao = d.TipoDespesa.Descricao
                }
            })
            .FirstOrDefaultAsync();

        if (orcamento == null)
            return NotFound("Orçamento não encontrado");

        return Ok(orcamento);
    }

    // Método para adicionar novo Orçamento
    [HttpPost]
    public async Task<ActionResult> Cadastrar([FromBody] OrcamentoAdicionarAtualizarDTO orcamentoDto)
    {
        if (orcamentoDto == null)
            return BadRequest("Dados inválidos");

        var orcamento = new OrcamentoModel
        {
            AnoOrcamento = orcamentoDto.AnoOrcamento,
            ValorOrcamento = orcamentoDto.ValorOrcamento,
            IdInstituicao = orcamentoDto.IdInstituicao,
            IdTipoDespesa = orcamentoDto.IdTipoDespesa
        };

        _context.Orcamento.Add(orcamento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = orcamento.Id }, orcamento);
    }

    // Método para atualizar Orçamento existente
    [HttpPut()]
    public async Task<ActionResult> Atualizar([FromBody] OrcamentoAdicionarAtualizarDTO orcamentoAtualizada)
    {
        if (orcamentoAtualizada == null || orcamentoAtualizada.Id != orcamentoAtualizada.Id)
            return BadRequest("Dados inválidos");

        var orcamentoExistente = await _context.Orcamento.FindAsync(orcamentoAtualizada.Id);

        if (orcamentoExistente == null)
            return NotFound("Orçamento não encontrado");

        _context.Entry(orcamentoExistente).CurrentValues.SetValues(orcamentoAtualizada);
        await _context.SaveChangesAsync();

        return Ok(orcamentoAtualizada);
    }

    // Método para deletar orçamento
    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> Apagar(int id)
    {
        var orcamento = await _context.Orcamento.FindAsync(id);

        if (orcamento == null)
            return NotFound("Orçamento não encontrado");

        _context.Orcamento.Remove(orcamento);
        await _context.SaveChangesAsync();

        var orcamentoRemovida = new OrcamentoDTO
        {
            AnoOrcamento = orcamento.AnoOrcamento,
            ValorOrcamento = orcamento.ValorOrcamento,
            Instituicao = new InstituicaoDTO
            {
                Id = orcamento.Instituicao.Id,
                Nome = orcamento.Instituicao.Nome
            },
            TipoDespesa = new TipoDespesaDTO
            {
                Id = orcamento.TipoDespesa.Id,
                Descricao = orcamento.TipoDespesa.Descricao
            }
        };

        return Ok(orcamentoRemovida);
    }
}
