using api.Models;
using api.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class UsuarioDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O CPF do Usuario é requerido!")]
        [MinLength(11)]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Nome é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O RG é requerido!")]
        [MinLength(7)]
        [MaxLength(12)]
        public string Rg {  get; set; }

        [Required(ErrorMessage = "O Logradouro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é requerido!")]
        [MinLength(1)]
        [MaxLength(15)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "A Cidade é requerida!")]
        [MinLength(1)]
        [MaxLength(25)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é requerido!")]
        [MinLength(1)]
        [MaxLength(25)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é requerido!")]
        [MinLength(8)]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Bairro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Email é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é requerida!")]
        [MinLength(1)]
        [MaxLength(15)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A Situação do Usuário é requerida!")]
        public EnumSituacaoModel Situacao { get; set; }


        [Required(ErrorMessage = "O Tipo do Usuário é requerido!")]
        public TipoUsuarioEnum TipoUsuario { get; set; }

        [Required(ErrorMessage = "A Matrícula é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Matricula { get; set; }
    }
}
