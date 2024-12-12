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

    // Método para buscar todos os orçamentos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrcamentoParametroDTO>>> BuscarTodosDespesa()
    {
        var orcamentos = await _context.Orcamento
            .Select(o => new OrcamentoParametroDTO
            {
                Id = o.Id,
                AnoOrcamento = o.AnoOrcamento,
                ValorOrcamento = o.ValorOrcamento,
                Instituicao = new InstituicoesParametro
                {
                    Id = o.Instituicao.Id,
                    Nome = o.Instituicao.Nome
                },
                TipoDespesa = new TipoDespesaParametros
                {
                    Id = o.TipoDespesa.Id,
                    Descricao = o.TipoDespesa.Descricao
                }
            })
            .ToListAsync();

        return Ok(orcamentos);
    }

    // Método para buscar orçamento por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<OrcamentoParametroDTO>> BuscarPorId(int id)
    {
        var orcamento = await _context.Orcamento
            .Where(o => o.Id == id)
            .Select(o => new OrcamentoParametroDTO
            {
                Id = o.Id,
                AnoOrcamento = o.AnoOrcamento,
                ValorOrcamento = o.ValorOrcamento,
                Instituicao = new InstituicoesParametro
                {
                    Id = o.Instituicao.Id,
                    Nome = o.Instituicao.Nome
                },
                TipoDespesa = new TipoDespesaParametros
                {
                    Id = o.TipoDespesa.Id,
                    Descricao = o.TipoDespesa.Descricao
                }
            })
            .FirstOrDefaultAsync();

        if (orcamento == null)
            return NotFound("Orçamento não encontrado");

        return Ok(orcamento);
    }

    // Método para adicionar novo orçamento
    [HttpPost]
    public async Task<ActionResult<OrcamentoParametroDTO>> Cadastrar([FromBody] OrcamentoParametroDTO orcamentoDto)
    {
        if (orcamentoDto == null)
            return BadRequest("Dados inválidos");

        var novoOrcamento = new OrcamentoModel
        {
            AnoOrcamento = orcamentoDto.AnoOrcamento,
            ValorOrcamento = orcamentoDto.ValorOrcamento,
            IdInstituicao = orcamentoDto.Instituicao.Id,
            IdTipoDespesa = orcamentoDto.TipoDespesa.Id
        };

        _context.Orcamento.Add(novoOrcamento);
        await _context.SaveChangesAsync();

        // Carregar o orçamento cadastrado com entidades relacionadas
        var orcamentoCadastrado = await _context.Orcamento
            .Include(o => o.Instituicao)
            .Include(o => o.TipoDespesa)
            .FirstOrDefaultAsync(o => o.Id == novoOrcamento.Id);

        if (orcamentoCadastrado == null)
            return NotFound();

        var orcamentoDados = new OrcamentoParametroDTO
        {
            Id = orcamentoCadastrado.Id,
            AnoOrcamento = orcamentoCadastrado.AnoOrcamento,
            ValorOrcamento = orcamentoCadastrado.ValorOrcamento,
            Instituicao = new InstituicoesParametro
            {
                Id = orcamentoCadastrado.Instituicao.Id,
                Nome = orcamentoCadastrado.Instituicao.Nome
            },
            TipoDespesa = new TipoDespesaParametros
            {
                Id = orcamentoCadastrado.TipoDespesa.Id,
                Descricao = orcamentoCadastrado.TipoDespesa.Descricao
            }
        };

        return Ok(orcamentoDados);
    }

    // Método para atualizar orçamento existente
    [HttpPut]
    public async Task<ActionResult<OrcamentoParametroDTO>> Atualizar([FromBody] OrcamentoParametroDTO orcamentoDto)
    {
        if (orcamentoDto == null || orcamentoDto.Id == 0)
            return BadRequest("Dados inválidos");

        var orcamentoExistente = await _context.Orcamento.FindAsync(orcamentoDto.Id);

        if (orcamentoExistente == null)
            return NotFound("Orçamento não encontrado");

        // Atualização dos atributos do orçamento existente
        orcamentoExistente.AnoOrcamento = orcamentoDto.AnoOrcamento;
        orcamentoExistente.ValorOrcamento = orcamentoDto.ValorOrcamento;

        // Atualização de subobjetos
        orcamentoExistente.IdInstituicao = orcamentoDto.Instituicao.Id;
        orcamentoExistente.IdTipoDespesa = orcamentoDto.TipoDespesa.Id;

        await _context.SaveChangesAsync();

        // Carregar o orçamento cadastrado com entidades relacionadas
        var orcamentoAtualizado = await _context.Orcamento
            .Include(o => o.Instituicao)
            .Include(o => o.TipoDespesa)
            .FirstOrDefaultAsync(o => o.Id == orcamentoExistente.Id);

        // Criar DTO com os dados atualizados
        var orcamentoDados = new OrcamentoParametroDTO
        {
            Id = orcamentoAtualizado.Id,
            AnoOrcamento = orcamentoAtualizado.AnoOrcamento,
            ValorOrcamento = orcamentoAtualizado.ValorOrcamento,
            Instituicao = new InstituicoesParametro
            {
                Id = orcamentoAtualizado.Instituicao.Id,
                Nome = orcamentoAtualizado.Instituicao.Nome
            },
            TipoDespesa = new TipoDespesaParametros
            {
                Id = orcamentoAtualizado.TipoDespesa.Id,
                Descricao = orcamentoAtualizado.TipoDespesa.Descricao
            }
        };

        return Ok(orcamentoDados);
    }

    // Método para excluir orçamento
    [HttpDelete("{id}")]
    public async Task<IActionResult> Apagar(int id)
    {
        var orcamento = await _context.Orcamento.FindAsync(id);

        if (orcamento == null)
            return NotFound("Orçamento não encontrado");

        _context.Orcamento.Remove(orcamento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
