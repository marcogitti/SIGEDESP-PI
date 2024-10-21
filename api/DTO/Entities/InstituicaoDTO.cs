using api.Models;
using api.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static api.DTO.Entities.ObjetosSimplificados;

namespace api.DTO.Entities
{
    public class InstituicaoDTO
    {
        public int Id { get; set; }
        public EnumSituacaoModel Situacao { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        // Subobjetos simplificados
        public TipoInstituicaoDTO TipoInstituicao { get; set; }
        public SecretariaDTO Secretaria { get; set; }
        public DTOTipoInstituicao DTOTipoInstituicao { get; set; }
        public DTOSecretaria DTOSecretaria { get; set; }
    }
}
