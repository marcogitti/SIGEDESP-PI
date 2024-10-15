using api.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Entities
{
    public class TipoDespesaAdicionarAtualizarDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A Descrição é requerida!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Situação é requerida!")]
        public EnumSolicitaUCModel SolicitaUC { get; set; }

        [Required(ErrorMessage = "O ID de Unidade de Medida é requerido!")]
        public int IdUnidadeMedida { get; set; }
    }
}
