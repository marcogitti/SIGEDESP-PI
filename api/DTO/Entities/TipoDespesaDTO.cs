using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class TipoDespesaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do Tipo Despesa é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string TipoDespesa { get; set; }

        [Required(ErrorMessage = "O Solicita Unidade Consumidora é requerido!")]
        public string SolicitaUC { get; set; }

    }
}
