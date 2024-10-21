using api.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Entities
{
    public class InstituicaoAdicionarAtualizarDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A Situação é requerida!")]
        public EnumSituacaoModel Situacao { get; set; }

        [Required(ErrorMessage = "O CNPJ é requerido!")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O Nome é requerido!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Logradouro é requerido!")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é requerido!")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O Bairro é requerido!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O CEP é requerido!")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O Nome Razão Social é requerido!")]
        public string NomeRazaoSocial { get; set; }

        [Required(ErrorMessage = "O Telefone é requerido!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Email é requerido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Cidade é requerida!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é requerido!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O ID de Tipo Instituição é requerido!")]
        public int IdTipoInstituicao { get; set; }

        [Required(ErrorMessage = "O ID de Secretaria é requerido!")]
        public int IdSecretaria { get; set; }
    }
}
