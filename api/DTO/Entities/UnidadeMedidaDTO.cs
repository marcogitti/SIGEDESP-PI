using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class UnidadeMedidaDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A descrição da Unidade de Medida é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A abreviatura da Unidade de Medida é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Abreviatura { get; set; }

    }
}