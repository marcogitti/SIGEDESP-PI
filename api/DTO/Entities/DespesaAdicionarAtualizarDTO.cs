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

        [Required(ErrorMessage = "O Ano de Emissão é requerido!")]
        public int AnoEmissao { get; set; }

        [Required(ErrorMessage = "O Semestre de Emissão é requerido!")]
        public int SemestreEmissao { get; set; }

        [Required(ErrorMessage = "O Trimestre de Emissão é requerido!")]
        public int TrimestreEmissao { get; set; }

        [Required(ErrorMessage = "O Mês de Emissão é requerido!")]
        public int MesEmissao { get; set; }

        [Required(ErrorMessage = "A Situação de Despesa é requerida!")]
        public EnumStatusDespesaModel StatusDespesa { get; set; }

        // Apenas IDs para chaves estrangeiras
        [Required(ErrorMessage = "O ID do Fornecedor é requerido!")]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "O ID da Unidade Consumidora é requerido!")]
        public int IdUnidadeConsumidora { get; set; }

        [Required(ErrorMessage = "O ID da Instituição é requerido!")]
        public int IdInstituicao { get; set; }

        [Required(ErrorMessage = "O ID do Orçamento é requerido!")]
        public int IdOrcamento { get; set; }

        [Required(ErrorMessage = "O ID do Tipo de Despesa é requerido!")]
        public int IdTipoDespesa { get; set; }

        [Required(ErrorMessage = "O ID do Usuário é requerido!")]
        public int IdUsuario { get; set; }
    }
}
