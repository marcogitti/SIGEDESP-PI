using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class UnidadeConsumidoraDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O código de Unidade Consumidora é requerido!")]
        public int CodigoUC { get; set; }

    }
}