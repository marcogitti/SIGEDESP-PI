using api.Models;
using api.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class TipoDespesaDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O nome do Tipo Despesa é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Unidade Consumidora é requerida!")]
        public EnumSolicitaUCModel SolicitaUC { get; set; }

        /*
        [Required(ErrorMessage = "O Solicita Unidade Consumidora é requerido!")]
        public string SolicitaUC { get; set; }
        */

        /*Código para colocar atributos da classes que dão chave estrangeira no cadastro*/
        [JsonIgnore]
        public UnidadeMedidaModel? UnidadeMedida { get; set; }

        [Required(ErrorMessage = "O ID de Unidade de Medida é requerido!")]
        public int IdUnidadeMedida { get; set; }

    }
}
