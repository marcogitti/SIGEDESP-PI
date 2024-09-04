using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class TipoInstituicaoDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A Descrição é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Nome é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Nome { get; set; }

    }
}
