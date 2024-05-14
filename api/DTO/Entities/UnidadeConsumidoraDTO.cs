using api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class UnidadeConsumidoraDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O código de Unidade Consumidora é requerido!")]
        public int CodigoUC { get; set; }

        [JsonIgnore]
        public FornecedorModel? Fornecedor { get; set; }

        [Required(ErrorMessage = "O ID de Fornecedor é requerido!")]
        public int IdFornecedor { get; set; }

    }
}