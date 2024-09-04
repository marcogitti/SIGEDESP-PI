using api.Models;
using api.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class DespesaDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Número do Documento é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "A Situação é requerida!")]
        public SituacaoEnum Situacao { get; set; }

        [Required(ErrorMessage = "O Número de Controle é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NumeroControle { get; set; }

        [Required(ErrorMessage = "O Ano e Mês de consumo são requeridos!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string AnoMesConsumo { get; set; }


        [Required(ErrorMessage = "A Quantidade Consumida é requerida!")]
        public double QuantidadeConsumida { get; set; }

        [Required(ErrorMessage = "O Valor Previsto é requerido!")]
        public double ValorPrevisto { get; set; }

        [Required(ErrorMessage = "O Valor Pago é requerido!")]
        public double ValorPago { get; set; }

        [Required(ErrorMessage = "A Data de Vencimento é requerida!")]
        public DateOnly DataVencimento { get; set; }

        [Required(ErrorMessage = "A Data de Pagamento é requerida!")]
        public DateOnly DataPagamento { get; set; }

        public int AnoEmissao { get; set; }

        public int SemestreEmissao { get; set; }

        public int TrimestreEmissao { get; set; }

        public int MesEmissao { get; set; }

        [JsonIgnore]
        public UsuarioModel? Usuario { get; set; }

        [Required(ErrorMessage = "O ID de Usuário é requerido!")]
        public int IdUsuario { get; set; }


        [JsonIgnore]
        public FornecedorModel? Fornecedor { get; set; }

        [Required(ErrorMessage = "O ID de Fornecedor é requerido!")]
        public int IdFornecedor { get; set; }


        [JsonIgnore]
        public UnidadeConsumidoraModel? UnidadeConsumidora { get; set; }

        [Required(ErrorMessage = "O ID de Unidade Consumidora é requerido!")]
        public int IdUnidadeConsumidora { get; set; }


        [JsonIgnore]
        public InstituicaoModel? Instituicao { get; set; }

        [Required(ErrorMessage = "O ID de Instituição é requerido!")]
        public int IdInstituicao { get; set; }


        [JsonIgnore]
        public OrcamentoModel? Orcamento { get; set; }

        [Required(ErrorMessage = "O ID de Orçamento é requerido!")]
        public int IdOrcamento { get; set; }


        [JsonIgnore]
        public TipoDespesaModel? TipoDespesa { get; set; }

        [Required(ErrorMessage = "O ID de Tipo de Despesa é requerido!")]
        public int IdTipoDespesa { get; set; }


    }
}

