using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class OrcamentoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Ano do Orçamento é requerido!")]
        public int AnoOrcamento { get; set; }

        [Required(ErrorMessage = "O Valor do Orçamento é requerido!")]
        public double ValorOrcamento { get; set; }

    }
}
