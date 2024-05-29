using api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class UsuarioDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O CPF ou o CNPJ do Usuario é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O Nome Razão Social é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NomeRazaoSocial { get; set; }

        public int RgLe {  get; set; }

        [Required(ErrorMessage = "O Logradouro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        [Required(ErrorMessage = "A Cidade é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Estado { get; set; }

        public int CEP { get; set; }

        [Required(ErrorMessage = "O Bairro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Rua é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O Email é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A Situação do Usuário é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "A Matrícula é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Matricula { get; set; }

        /*Código para colocar atributos da classes que dão chave estrangeira no cadastro*/
        [JsonIgnore]
        public TipoUsuarioModel? TipoUsuario { get; set; }

        [Required(ErrorMessage = "O ID de Tipo Usuário é requerido!")]
        public int IdTipoUsuario { get; set; }
    }
}
