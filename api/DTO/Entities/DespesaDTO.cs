using api.Models.Enum;
using static api.DTO.Entities.ObjetosSimplificados;

namespace api.DTO.Entities
{
    public class DespesaDTO
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroControle { get; set; }
        public string AnoMesConsumo { get; set; }
        public double QuantidadeConsumida { get; set; }
        public DateOnly DataVencimento { get; set; }
        public double ValorPrevisto { get; set; }
        public DateOnly DataPagamento { get; set; }
        public double ValorPago { get; set; }
        public int AnoEmissao { get; set; }
        public int SemestreEmissao { get; set; }
        public int TrimestreEmissao { get; set; }
        public int MesEmissao { get; set; }
        public EnumSituacaoModel Situacao { get; set; }
        public EnumStatusDespesaModel StatusDespesa { get; set; }

        // Subobjetos simplificados
        public FornecedorDTO Fornecedor { get; set; }
        public UnidadeConsumidoraDTO UnidadeConsumidora { get; set; }
        public InstituicaoDTO Instituicao { get; set; }
        public OrcamentoDTO Orcamento { get; set; }
        public TipoDespesaDTO TipoDespesa { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public DTOFornecedor DTOFornecedor { get; set; }
        public DTOUnidadeConsumidora DTOUnidadeConsumidora { get; set; }
        public DTOInstituicao DTOInstituicao { get; set; }
        public DTOOrcamento DTOOrcamento { get; set; }
        public DTOTipoDespesa DTOTipoDespesa { get; set; }
        public DTOUsuario DTOUsuario { get; set; }
    }
}
