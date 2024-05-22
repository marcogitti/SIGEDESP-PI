using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class TipoUsuarioDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Descrição do Tipo Usuario é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Permite Login é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string PermiteLogin { get; set; }

    }
}
