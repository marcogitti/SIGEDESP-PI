using api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class UnidadeConsumidoraDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O Código de Unidade Consumidora é requerido!")]
        [MinLength(1)]
        [MaxLength(10)]
        public string CodigoUC { get; set; }

        /*Código para colocar atributos das classes que dão chave estrangeira no cadastro*/
        [JsonIgnore]
        public FornecedorModel? Fornecedor { get; set; }

        [Required(ErrorMessage = "O ID de Fornecedor é requerido!")]
        public int IdFornecedor { get; set; }


        [JsonIgnore]
        public InstituicaoModel? Instituicao { get; set; }

        [Required(ErrorMessage = "O ID de Instituição é requerido!")]
        public int IdInstituicao { get; set; }

    }
}