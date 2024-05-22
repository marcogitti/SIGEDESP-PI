using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class SecretariaDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A Situação da Secretaria é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "A Descrição é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

    }
}
