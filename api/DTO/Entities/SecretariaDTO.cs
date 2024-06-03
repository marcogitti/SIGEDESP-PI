using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.DTO.Entities
{
    public class SecretariaDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A Situação da Secretaria é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "A Descrição é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O CNPJ é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O Nome é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Logradouro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O Bairro é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Rua é requerida!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O CEP é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public int Cep { get; set; }

        [Required(ErrorMessage = "O Nome de Razão Social é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string nomeRazaoSocial { get; set; }

        [Required(ErrorMessage = "O Telefone é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O E-mail é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Email { get; set; }

    }
}
