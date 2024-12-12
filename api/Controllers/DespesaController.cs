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
    public async Task<ActionResult<IEnumerable<DespesaParametroDTO>>> BuscarTodosDespesa()
    {
        var despesas = await _context.Despesa
            .Select(d => new DespesaParametroDTO
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
                Fornecedor = new FornecedorParametro
                {
                    Id = d.Fornecedor.Id,
                    NomeFantasia = d.Fornecedor.NomeFantasia
                },
                UnidadeConsumidora = new UnidadeConsumidoraParametro
                {
                    Id = d.UnidadeConsumidora.Id,
                    CodigoUC = d.UnidadeConsumidora.CodigoUC
                },
                Instituicao = new InstituicaoParametro
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
                Orcamento = new OrcamentoParametro
                {
                    Id = d.Orcamento.Id,
                    ValorOrcamento = d.Orcamento.ValorOrcamento
                },
                TipoDespesa = new TipoDespesaParametro
                {
                    Id = d.TipoDespesa.Id,
                    Descricao = d.TipoDespesa.Descricao
                },
                Usuario = new UsuarioParametro
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
    public async Task<ActionResult<DespesaParametroDTO>> BuscarPorId(int id)
    {
        var despesa = await _context.Despesa
            .Where(d => d.Id == id)
            .Select(d => new DespesaParametroDTO
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
                Fornecedor = new FornecedorParametro
                {
                    Id = d.Fornecedor.Id,
                    NomeFantasia = d.Fornecedor.NomeFantasia
                },
                UnidadeConsumidora = new UnidadeConsumidoraParametro
                {
                    Id = d.UnidadeConsumidora.Id,
                    CodigoUC = d.UnidadeConsumidora.CodigoUC
                },
                Instituicao = new InstituicaoParametro
                {
                    Id = d.Instituicao.Id,
                    Nome = d.Instituicao.Nome
                },
                Orcamento = new OrcamentoParametro
                {
                    Id = d.Orcamento.Id,
                    ValorOrcamento = d.Orcamento.ValorOrcamento
                },
                TipoDespesa = new TipoDespesaParametro
                {
                    Id = d.TipoDespesa.Id,
                    Descricao = d.TipoDespesa.Descricao
                },
                Usuario = new UsuarioParametro
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
    public async Task<ActionResult<DespesaParametroDTO>> Cadastrar([FromBody] DespesaParametroDTO despesaDto)
    {
        if (despesaDto == null)
            return BadRequest("Dados inválidos");

        var novaDespesa = new DespesaModel
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
            StatusDespesa = despesaDto.StatusDespesa,
            IdFornecedor = despesaDto.Fornecedor.Id,
            IdUnidadeConsumidora = despesaDto.UnidadeConsumidora.Id,
            IdInstituicao = despesaDto.Instituicao.Id,
            IdOrcamento = despesaDto.Orcamento.Id,
            IdTipoDespesa = despesaDto.TipoDespesa.Id,
            IdUsuario = despesaDto.Usuario.Id
        };

        _context.Despesa.Add(novaDespesa);
        await _context.SaveChangesAsync();

        // Carregar a despesa cadastrada com entidades relacionadas
        var despesaCadastrada = await _context.Despesa
            .Include(d => d.Fornecedor)
            .Include(d => d.UnidadeConsumidora)
            .Include(d => d.Instituicao)
            .Include(d => d.Orcamento)
            .Include(d => d.TipoDespesa)
            .Include(d => d.Usuario)
            .FirstOrDefaultAsync(d => d.Id == novaDespesa.Id);

        if (despesaCadastrada == null)
            return NotFound();

        var despesaDados = new DespesaParametroDTO
        {
            Id = despesaCadastrada.Id,
            NumeroDocumento = despesaCadastrada.NumeroDocumento,
            NumeroControle = despesaCadastrada.NumeroControle,
            AnoMesConsumo = despesaCadastrada.AnoMesConsumo,
            QuantidadeConsumida = despesaCadastrada.QuantidadeConsumida,
            DataVencimento = despesaCadastrada.DataVencimento,
            ValorPrevisto = despesaCadastrada.ValorPrevisto,
            DataPagamento = despesaCadastrada.DataPagamento,
            ValorPago = despesaCadastrada.ValorPago,
            AnoEmissao = despesaCadastrada.AnoEmissao,
            SemestreEmissao = despesaCadastrada.SemestreEmissao,
            TrimestreEmissao = despesaCadastrada.TrimestreEmissao,
            MesEmissao = despesaCadastrada.MesEmissao,
            Situacao = despesaCadastrada.Situacao,
            StatusDespesa = despesaCadastrada.StatusDespesa,
            Fornecedor = new FornecedorParametro
            {
                Id = despesaCadastrada.Fornecedor.Id,
                NomeFantasia = despesaCadastrada.Fornecedor.NomeFantasia
            },
            UnidadeConsumidora = new UnidadeConsumidoraParametro
            {
                Id = despesaCadastrada.UnidadeConsumidora.Id,
                CodigoUC = despesaCadastrada.UnidadeConsumidora.CodigoUC
            },
            Instituicao = new InstituicaoParametro
            {
                Id = despesaCadastrada.Instituicao.Id,
                Nome = despesaCadastrada.Instituicao.Nome
            },
            Orcamento = new OrcamentoParametro
            {
                Id = despesaCadastrada.Orcamento.Id,
                ValorOrcamento = despesaCadastrada.Orcamento.ValorOrcamento
            },
            TipoDespesa = new TipoDespesaParametro
            {
                Id = despesaCadastrada.TipoDespesa.Id,
                Descricao = despesaCadastrada.TipoDespesa.Descricao
            },
            Usuario = new UsuarioParametro
            {
                Id = despesaCadastrada.Usuario.Id,
                Nome = despesaCadastrada.Usuario.Nome
            }
        };

        return Ok(despesaDados);
    }

    // Método para atualizar despesa existente
    [HttpPut]
    public async Task<ActionResult<DespesaParametroDTO>> Atualizar([FromBody] DespesaParametroDTO despesaDto)
    {
        if (despesaDto == null || despesaDto.Id == 0)
            return BadRequest("Dados inválidos");

        var despesaExistente = await _context.Despesa.FindAsync(despesaDto.Id);

        if (despesaExistente == null)
            return NotFound("Despesa não encontrada");

        // Atualização dos atributos da despesa existente
        despesaExistente.NumeroDocumento = despesaDto.NumeroDocumento;
        despesaExistente.NumeroControle = despesaDto.NumeroControle;
        despesaExistente.AnoMesConsumo = despesaDto.AnoMesConsumo;
        despesaExistente.QuantidadeConsumida = despesaDto.QuantidadeConsumida;
        despesaExistente.ValorPrevisto = despesaDto.ValorPrevisto;
        despesaExistente.ValorPago = despesaDto.ValorPago;
        despesaExistente.DataVencimento = despesaDto.DataVencimento;
        despesaExistente.DataPagamento = despesaDto.DataPagamento;
        despesaExistente.AnoEmissao = despesaDto.AnoEmissao;
        despesaExistente.SemestreEmissao = despesaDto.SemestreEmissao;
        despesaExistente.TrimestreEmissao = despesaDto.TrimestreEmissao;
        despesaExistente.MesEmissao = despesaDto.MesEmissao;
        despesaExistente.StatusDespesa = despesaDto.StatusDespesa;
        despesaExistente.Situacao = despesaDto.Situacao;

        // Atualização de subobjetos
        despesaExistente.IdFornecedor = despesaDto.Fornecedor.Id;
        despesaExistente.IdUnidadeConsumidora = despesaDto.UnidadeConsumidora.Id;
        despesaExistente.IdInstituicao = despesaDto.Instituicao.Id;
        despesaExistente.IdOrcamento = despesaDto.Orcamento.Id;
        despesaExistente.IdTipoDespesa = despesaDto.TipoDespesa.Id;
        despesaExistente.IdUsuario = despesaDto.Usuario.Id;

        await _context.SaveChangesAsync();

        // Carregar a despesa cadastrada com entidades relacionadas
        var despesaAtualizada = await _context.Despesa
            .Include(d => d.Fornecedor)
            .Include(d => d.UnidadeConsumidora)
            .Include(d => d.Instituicao)
            .Include(d => d.Orcamento)
            .Include(d => d.TipoDespesa)
            .Include(d => d.Usuario)
            .FirstOrDefaultAsync(d => d.Id == despesaExistente.Id);

        // Criar DTO com os dados atualizados
        var despesaDados = new DespesaParametroDTO
        {
            Id = despesaAtualizada.Id,
            NumeroDocumento = despesaAtualizada.NumeroDocumento,
            NumeroControle = despesaAtualizada.NumeroControle,
            AnoMesConsumo = despesaAtualizada.AnoMesConsumo,
            QuantidadeConsumida = despesaAtualizada.QuantidadeConsumida,
            DataVencimento = despesaAtualizada.DataVencimento,
            ValorPrevisto = despesaAtualizada.ValorPrevisto,
            DataPagamento = despesaAtualizada.DataPagamento,
            ValorPago = despesaAtualizada.ValorPago,
            AnoEmissao = despesaAtualizada.AnoEmissao,
            SemestreEmissao = despesaAtualizada.SemestreEmissao,
            TrimestreEmissao = despesaAtualizada.TrimestreEmissao,
            MesEmissao = despesaAtualizada.MesEmissao,
            Situacao = despesaAtualizada.Situacao,
            StatusDespesa = despesaAtualizada.StatusDespesa,
            Fornecedor = new FornecedorParametro
            {
                Id = despesaAtualizada.Fornecedor.Id,
                NomeFantasia = despesaAtualizada.Fornecedor.NomeFantasia
            },
            UnidadeConsumidora = new UnidadeConsumidoraParametro
            {
                Id = despesaAtualizada.UnidadeConsumidora.Id,
                CodigoUC = despesaAtualizada.UnidadeConsumidora.CodigoUC
            },
            Instituicao = new InstituicaoParametro
            {
                Id = despesaAtualizada.Instituicao.Id,
                Nome = despesaAtualizada.Instituicao.Nome
            },
            Orcamento = new OrcamentoParametro
            {
                Id = despesaAtualizada.Orcamento.Id,
                ValorOrcamento = despesaAtualizada.Orcamento.ValorOrcamento
            },
            TipoDespesa = new TipoDespesaParametro
            {
                Id = despesaAtualizada.TipoDespesa.Id,
                Descricao = despesaAtualizada.TipoDespesa.Descricao
            },
            Usuario = new UsuarioParametro
            {
                Id = despesaAtualizada.Usuario.Id,
                Nome = despesaAtualizada.Usuario.Nome
            }
        };

        return Ok(despesaDados);
    }

    // Método para excluir despesa
    [HttpDelete("{id}")]
    public async Task<IActionResult> Apagar(int id)
    {
        var despesa = await _context.Despesa.FindAsync(id);

        if (despesa == null)
            return NotFound("Despesa não encontrada");

        _context.Despesa.Remove(despesa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
