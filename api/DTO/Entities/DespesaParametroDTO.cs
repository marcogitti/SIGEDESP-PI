using api.Models.Enum;

namespace api.DTO.Entities
{
    public class DespesaParametroDTO
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroControle { get; set; }
        public string AnoMesConsumo { get; set; }
        public double QuantidadeConsumida { get; set; }
        public DateOnly DataVencimento { get; set; }
        public double ValorPrevisto { get; set; }
        public DateOnly? DataPagamento { get; set; }
        public double ValorPago { get; set; }
        public int AnoEmissao { get; set; }
        public int SemestreEmissao { get; set; }
        public int TrimestreEmissao { get; set; }
        public int MesEmissao { get; set; }
        public EnumSituacaoModel Situacao { get; set; }
        public EnumStatusDespesaModel StatusDespesa { get; set; }

        public FornecedorParametro Fornecedor { get; set; }
        public UnidadeConsumidoraParametro UnidadeConsumidora { get; set; }
        public InstituicaoParametro Instituicao { get; set; }
        public OrcamentoParametro Orcamento { get; set; }
        public TipoDespesaParametro TipoDespesa { get; set; }
        public UsuarioParametro Usuario { get; set; }
    }

    public class FornecedorParametro
    {
        public int Id { get; set; }
        public string? NomeFantasia { get; set; }
    }

    public class UnidadeConsumidoraParametro
    {
        public int Id { get; set; }
        public string? CodigoUC { get; set; }
    }

    public class InstituicaoParametro
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }

    public class OrcamentoParametro
    {
        public int Id { get; set; }
        public double? ValorOrcamento { get; set; }
    }

    public class TipoDespesaParametro
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }

    public class UsuarioParametro
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }

}
