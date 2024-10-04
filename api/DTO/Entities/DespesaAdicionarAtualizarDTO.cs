using api.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Entities
{
    public class DespesaAdicionarAtualizarDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Número do Documento é requerido!")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "A Situação é requerida!")]
        public EnumSituacaoModel Situacao { get; set; }

        [Required(ErrorMessage = "O Número de Controle é requerido!")]
        public string NumeroControle { get; set; }

        [Required(ErrorMessage = "O Ano e Mês de consumo são requeridos!")]
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

        [Required(ErrorMessage = "O ID de Usuário é requerido!")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O ID de Fornecedor é requerido!")]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "O ID de Unidade Consumidora é requerido!")]
        public int IdUnidadeConsumidora { get; set; }

        [Required(ErrorMessage = "O ID de Instituição é requerido!")]
        public int IdInstituicao { get; set; }

        [Required(ErrorMessage = "O ID de Orçamento é requerido!")]
        public int IdOrcamento { get; set; }

        [Required(ErrorMessage = "A Situação de Despesa é requerida!")]
        public EnumStatusDespesaModel StatusDespesa { get; set; }

        [Required(ErrorMessage = "O ID de Tipo de Despesa é requerido!")]
        public int IdTipoDespesa { get; set; }
    }
}
