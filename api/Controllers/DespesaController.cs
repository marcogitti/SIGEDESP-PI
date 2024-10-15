using api.Data;
using api.DTO.Entities;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/despesa")]
public class DespesaController : ControllerBase
{
    private readonly SigedespDBContex _context;

    public DespesaController(SigedespDBContex context)
    {
        _context = context;
    }

    // Método para buscar todas as despesas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> BuscarTodosDespesa()
    {
        var despesas = await _context.Despesa
            .Select(d => new
            {
                Id = d.Id,
                NumeroDocumento = d.NumeroDocumento,
                NumeroControle = d.NumeroControle,
                AnoMesConsumo = d.AnoMesConsumo,
                QuantidadeConsumida = d.QuantidadeConsumida,
                DataVencimento = d.DataVencimento,
                ValorPrevisto = d.ValorPrevisto,
                DataPagamento = d.DataPagamento,
                ValorPago = d.ValorPago,
                AnoEmissao = d.AnoEmissao,
                SemestreEmissao = d.SemestreEmissao,
                TrimestreEmissao = d.TrimestreEmissao,
                MesEmissao = d.MesEmissao,
                Situacao = d.Situacao,
                StatusDespesa = d.StatusDespesa,
                Fornecedor = new
                {
                    Id = d.Fornecedor.Id,
                    NomeFantasia = d.Fornecedor.NomeFantasia
                },
                UnidadeConsumidora = new
                {
                    Id = d.UnidadeConsumidora.Id,
                    CodigoUC = d.UnidadeConsumidora.CodigoUC
                },
                Instituicao = new
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
                Orcamento = new
                {
                    Id = d.Orcamento.Id,
                    ValorOrcamento = d.Orcamento.ValorOrcamento
                },
                TipoDespesa = new
                {
                    Id = d.TipoDespesa.Id,
                    Descricao = d.TipoDespesa.Descricao
                },
                Usuario = new
                {
                    Id = d.Usuario.Id,
                    Nome = d.Usuario.Nome
                }
            })
            .ToListAsync();

        return Ok(despesas);
    }

    // Método para buscar despesa por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> BuscarPorId(int id)
    {
        var despesa = await _context.Despesa
            .Where(d => d.Id == id)
            .Select(d => new
            {
                Id = d.Id,
                NumeroDocumento = d.NumeroDocumento,
                NumeroControle = d.NumeroControle,
                AnoMesConsumo = d.AnoMesConsumo,
                QuantidadeConsumida = d.QuantidadeConsumida,
                DataVencimento = d.DataVencimento,
                ValorPrevisto = d.ValorPrevisto,
                DataPagamento = d.DataPagamento,
                ValorPago = d.ValorPago,
                AnoEmissao = d.AnoEmissao,
                SemestreEmissao = d.SemestreEmissao,
                TrimestreEmissao = d.TrimestreEmissao,
                MesEmissao = d.MesEmissao,
                Situacao = d.Situacao,
                StatusDespesa = d.StatusDespesa,
                Fornecedor = new
                {
                    Id = d.Fornecedor.Id,
                    NomeFantasia = d.Fornecedor.NomeFantasia
                },
                UnidadeConsumidora = new
                {
                    Id = d.UnidadeConsumidora.Id,
                    CodigoUC = d.UnidadeConsumidora.CodigoUC
                },
                Instituicao = new
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
                Orcamento = new
                {
                    Id = d.Orcamento.Id,
                    ValorOrcamento = d.Orcamento.ValorOrcamento
                },
                TipoDespesa = new
                {
                    Id = d.TipoDespesa.Id,
                    Descricao = d.TipoDespesa.Descricao
                },
                Usuario = new
                {
                    Id = d.Usuario.Id,
                    Nome = d.Usuario.Nome
                }
            })
            .FirstOrDefaultAsync();

        if (despesa == null)
            return NotFound("Despesa não encontrada");

        return Ok(despesa);
    }

    // Método para adicionar nova despesa
    [HttpPost]
    public async Task<ActionResult> Cadastrar([FromBody] DespesaAdicionarAtualizarDTO despesaDto)
    {
        if (despesaDto == null)
            return BadRequest("Dados inválidos");

        var despesa = new DespesaModel
        {
            NumeroDocumento = despesaDto.NumeroDocumento,
            Situacao = despesaDto.Situacao,
            NumeroControle = despesaDto.NumeroControle,
            AnoMesConsumo = despesaDto.AnoMesConsumo,
            QuantidadeConsumida = despesaDto.QuantidadeConsumida,
            ValorPrevisto = despesaDto.ValorPrevisto,
            ValorPago = despesaDto.ValorPago,
            DataVencimento = despesaDto.DataVencimento,
            DataPagamento = despesaDto.DataPagamento,
            AnoEmissao = despesaDto.AnoEmissao,
            SemestreEmissao = despesaDto.SemestreEmissao,
            TrimestreEmissao = despesaDto.TrimestreEmissao,
            MesEmissao = despesaDto.MesEmissao,
            IdUsuario = despesaDto.IdUsuario,
            IdFornecedor = despesaDto.IdFornecedor,
            IdUnidadeConsumidora = despesaDto.IdUnidadeConsumidora,
            IdInstituicao = despesaDto.IdInstituicao,
            IdOrcamento = despesaDto.IdOrcamento,
            StatusDespesa = despesaDto.StatusDespesa,
            IdTipoDespesa = despesaDto.IdTipoDespesa
        };

        _context.Despesa.Add(despesa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = despesa.Id }, despesa);
    }

    // Método para atualizar despesa existente
    [HttpPut()]
    public async Task<ActionResult> Atualizar([FromBody] DespesaAdicionarAtualizarDTO despesaAtualizada)
    {
        if (despesaAtualizada == null || despesaAtualizada.Id != despesaAtualizada.Id)
            return BadRequest("Dados inválidos");

        var despesaExistente = await _context.Despesa.FindAsync(despesaAtualizada.Id);

        if (despesaExistente == null)
            return NotFound("Despesa não encontrada");

        _context.Entry(despesaExistente).CurrentValues.SetValues(despesaAtualizada);
        await _context.SaveChangesAsync();

        return Ok(despesaAtualizada);
    }

    // Método para deletar despesa
    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> Apagar(int id)
    {
        var despesa = await _context.Despesa.FindAsync(id);

        if (despesa == null)
            return NotFound("Despesa não encontrada");

        _context.Despesa.Remove(despesa);
        await _context.SaveChangesAsync();

        var despesaRemovida = new DespesaDTO
        {
            Id = despesa.Id,
            NumeroDocumento = despesa.NumeroDocumento,
            NumeroControle = despesa.NumeroControle,
            AnoMesConsumo = despesa.AnoMesConsumo,
            QuantidadeConsumida = despesa.QuantidadeConsumida,
            DataVencimento = despesa.DataVencimento,
            ValorPrevisto = despesa.ValorPrevisto,
            DataPagamento = despesa.DataPagamento,
            ValorPago = despesa.ValorPago,
            Fornecedor = new FornecedorDTO
            {
                Id = despesa.Fornecedor.Id,
                NomeFantasia = despesa.Fornecedor.NomeFantasia
            },
            UnidadeConsumidora = new UnidadeConsumidoraDTO
            {
                Id = despesa.UnidadeConsumidora.Id,
                CodigoUC = despesa.UnidadeConsumidora.CodigoUC
            },
            Instituicao = new InstituicaoDTO
            {
                Id = despesa.Instituicao.Id,
                Nome = despesa.Instituicao.Nome
            },
            Orcamento = new OrcamentoDTO
            {
                Id = despesa.Orcamento.Id,
                ValorOrcamento = despesa.Orcamento.ValorOrcamento
            },
            TipoDespesa = new TipoDespesaDTO
            {
                Id = despesa.TipoDespesa.Id,
                Descricao = despesa.TipoDespesa.Descricao
            },
            Usuario = new UsuarioDTO
            {
                Id = despesa.Usuario.Id,
                Nome = despesa.Usuario.Nome
            }
        };

        return Ok(despesaRemovida);
    }
}
