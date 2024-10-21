using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models.Enum;
using System.Text.Json.Serialization;

namespace api.Models
{
    [Table("despesa")]
    public class DespesaModel
    {
        [Key]
        [Column("despesaid")]
        public int Id { get; set; }

        [Column("numerodocumento")]
        public string NumeroDocumento { get; set; }

        [Column("numerocontrole")]
        public string NumeroControle { get; set; }

        [Column("anomesconsumo")]
        public string AnoMesConsumo { get; set; }

        [Column("quantidadeconsumida")]
        public double QuantidadeConsumida { get; set; }

        [Column("datavencimento")]
        public DateOnly DataVencimento { get; set; }

        [Column("valorprevisto")]
        public double ValorPrevisto { get; set; }

        [Column("datapagamento")]
        public DateOnly DataPagamento { get; set; }

        [Column("valorpago")]
        public double ValorPago { get; set; }

        [Column("anoemissao")]
        public int AnoEmissao { get; set; }

        [Column("semestreemissao")]
        public int SemestreEmissao { get; set; }

        [Column("trimestreemissao")]
        public int TrimestreEmissao { get; set; }

        [Column("mesemissao")]
        public int MesEmissao { get; set; }


        /*Código para receber enum de Situação*/
        [Column("situcao")]
        [EnumDataType(typeof(EnumSituacaoModel))]
        public EnumSituacaoModel Situacao { get; set; }

        /*Código para receber chave estrangeira de Fornecedor*/
        public FornecedorModel? Fornecedor { get; set; }

        [Column("fornecedorid")]
        [ForeignKey("fornecedorid")]
        public int IdFornecedor { get; set; }

        /*Código para receber chave estrangeira de Unidade Consumidora*/
        public UnidadeConsumidoraModel? UnidadeConsumidora { get; set; }

        [Column("unidadeconsumidoraid")]
        [ForeignKey("unidadeconsumidoraid")]
        public int IdUnidadeConsumidora { get; set; }

        /*Código para receber chave estrangeira de Instituição*/
        public InstituicaoModel? Instituicao { get; set; }

        [Column("instituicaoid")]
        [ForeignKey("instituicaoid")]
        public int IdInstituicao { get; set; }

        /*Código para receber chave estrangeira de Orçamento*/
        public OrcamentoModel? Orcamento { get; set; }

        [Column("orcamentoid")]
        [ForeignKey("orcamentoid")]
        public int IdOrcamento { get; set; }

        /*Código para receber chave estrangeira de Tipo Despesa*/
        public TipoDespesaModel? TipoDespesa { get; set; }

        [Column("tipodespesaid")]
        [ForeignKey("tipodespesaid")]
        public int IdTipoDespesa { get; set; }

        /*Código para receber enum de Status Despesa*/
        [Column("statusdespesa")]
        [EnumDataType(typeof(EnumStatusDespesaModel))]
        public EnumStatusDespesaModel StatusDespesa { get; set; }

        /*Código para receber chave estrangeira de Usuário*/
        public UsuarioModel? Usuario { get; set; }

        [Column("usuarioid")]
        [ForeignKey("usuarioid")]
        public int IdUsuario { get; set; }

    }
}
