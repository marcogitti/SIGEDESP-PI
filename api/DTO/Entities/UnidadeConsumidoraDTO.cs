using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class UnidadeConsumidoraDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O código de Unidade Consumidora é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public int codigoUC { get; set; }

        [JsonIgnore]
        public UnidadeConsumidoraDTO? UnidadeConDTO { get; set; }

    }
}