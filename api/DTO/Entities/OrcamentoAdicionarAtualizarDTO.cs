using api.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Entities
{
    public class OrcamentoAdicionarAtualizarDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Ano do Orçamento é requerido!")]
        public int AnoOrcamento { get; set; }

        [Required(ErrorMessage = "O Valor do Orçamento é requerido!")]
        public double ValorOrcamento { get; set; }

        [Required(ErrorMessage = "O ID de Instituição é requerido!")]
        public int IdInstituicao { get; set; }

        [Required(ErrorMessage = "O ID de Tipo de Despesa é requerido!")]
        public int IdTipoDespesa { get; set; }
    }
}
