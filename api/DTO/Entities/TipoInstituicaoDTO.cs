using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class TipoInstituicaoDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O nome do Tipo Instituição é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string TipoInstituicao { get; set; }

    }
}
