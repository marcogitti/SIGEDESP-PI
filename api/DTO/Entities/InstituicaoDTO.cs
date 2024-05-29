using api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class InstituicaoDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A Situação é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Situacao { get; set; }

        /*Código para colocar atributos da classes que dão chave estrangeira no cadastro*/
        [JsonIgnore]
        public TipoInstituicaoModel? TipoInstituicaoLista { get; set; }

        [Required(ErrorMessage = "O ID de Tipo Instituição é requerido!")]
        public int IdTipoInstituicao { get; set; }

        [JsonIgnore]
        public SecretariaModel? Secretaria { get; set; }

        [Required(ErrorMessage = "O ID de Secretaria é requerido!")]
        public int IdSecretaria { get; set; }

    }
}
