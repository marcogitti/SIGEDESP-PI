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

    // Método para buscar todos os tipo despesas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoDespesaParametroDTO>>> BuscarTodosDespesa()
    {
        var tipodespesas = await _context.TipoDespesa
            .Select(td => new TipoDespesaParametroDTO
            {
                Id = td.Id,
                Descricao = td.Descricao,
                SolicitaUC = td.SolicitaUC,
                UnidadeMedida  = new UnidadeMedidaParametro
                {
                    Id = td.UnidadeMedida.Id,
                    Descricao = td.UnidadeMedida.Descricao
                }
            })
            .ToListAsync();

        return Ok(tipodespesas);
    }

    // Método para buscar tipo despesa por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<TipoDespesaParametroDTO>> BuscarPorId(int id)
    {
        var tipodespesa = await _context.TipoDespesa
            .Where(td => td.Id == id)
            .Select(td => new TipoDespesaParametroDTO
            {
                Id = td.Id,
                Descricao = td.Descricao,
                SolicitaUC= td.SolicitaUC,
                UnidadeMedida = new UnidadeMedidaParametro
                {
                    Id = td.UnidadeMedida.Id,
                    Descricao = td.UnidadeMedida.Descricao
                }
            })
            .FirstOrDefaultAsync();

        if (tipodespesa == null)
            return NotFound("Tipo de Despesa não encontrado");

        return Ok(tipodespesa);
    }

    // Método para adicionar novo tipo despesa
    [HttpPost]
    public async Task<ActionResult<TipoDespesaParametroDTO>> Cadastrar([FromBody] TipoDespesaParametroDTO tipodespesaDto)
    {
        if (tipodespesaDto == null)
            return BadRequest("Dados inválidos");

        var novoTipoDespesa = new TipoDespesaModel
        {
            Descricao = tipodespesaDto.Descricao,
            SolicitaUC = tipodespesaDto.SolicitaUC,
            IdUnidadeMedida = tipodespesaDto.UnidadeMedida.Id
        };

        _context.TipoDespesa.Add(novoTipoDespesa);
        await _context.SaveChangesAsync();

        // Carregar o tipo despesa cadastrado com entidades relacionadas
        var tipodespesaCadastrado = await _context.TipoDespesa
            .Include(td => td.UnidadeMedida)
            .FirstOrDefaultAsync(td => td.Id == novoTipoDespesa.Id);

        if (tipodespesaCadastrado == null)
            return NotFound();

        var tipodespesaDados = new TipoDespesaParametroDTO
        {
            Id = tipodespesaCadastrado.Id,
            Descricao = tipodespesaCadastrado.Descricao,
            SolicitaUC = tipodespesaCadastrado.SolicitaUC,
            UnidadeMedida = new UnidadeMedidaParametro
            {
                Id = tipodespesaCadastrado.UnidadeMedida.Id,
                Descricao = tipodespesaCadastrado.UnidadeMedida.Descricao
            }
        };

        return Ok(tipodespesaDados);
    }

    // Método para atualizar tipo despesa existente
    [HttpPut]
    public async Task<ActionResult<TipoDespesaParametroDTO>> Atualizar([FromBody] TipoDespesaParametroDTO tipodespesaDto)
    {
        if (tipodespesaDto == null || tipodespesaDto.Id == 0)
            return BadRequest("Dados inválidos");

        var tipodespesaExistente = await _context.TipoDespesa.FindAsync(tipodespesaDto.Id);

        if (tipodespesaExistente == null)
            return NotFound("Tipo de Despesa não encontrado");

        // Atualização dos atributos do tipo despesa existente
        tipodespesaExistente.Descricao = tipodespesaDto.Descricao;
        tipodespesaExistente.SolicitaUC = tipodespesaDto.SolicitaUC;

        // Atualização de subobjetos
        tipodespesaExistente.IdUnidadeMedida = tipodespesaDto.UnidadeMedida.Id;

        await _context.SaveChangesAsync();

        // Carregar o tipo despesa cadastrado com entidades relacionadas
        var tipodespesaAtualizado = await _context.TipoDespesa
            .Include(td => td.UnidadeMedida)
            .FirstOrDefaultAsync(td => td.Id == tipodespesaExistente.Id);

        // Criar DTO com os dados atualizados
        var tipodespesaDados = new TipoDespesaParametroDTO
        {
            Id = tipodespesaAtualizado.Id,
            Descricao = tipodespesaAtualizado.Descricao,
            SolicitaUC = tipodespesaAtualizado.SolicitaUC,
            UnidadeMedida = new UnidadeMedidaParametro
            {
                Id = tipodespesaAtualizado.UnidadeMedida.Id,
                Descricao = tipodespesaAtualizado.UnidadeMedida.Descricao
            }
        };

        return Ok(tipodespesaDados);
    }

    // Método para excluir orçamento
    [HttpDelete("{id}")]
    public async Task<IActionResult> Apagar(int id)
    {
        var tipodespesa = await _context.TipoDespesa.FindAsync(id);

        if (tipodespesa == null)
            return NotFound("Tipo de Despesa não encontrado");

        _context.TipoDespesa.Remove(tipodespesa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
