using api.Models.Enum;

namespace api.DTO.Entities
{
    public class InstituicaoParametroDTO
    {
        public int Id { get; set; }
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
        public EnumSituacaoModel Situacao { get; set; }

        public TipoInstituicaoParametro TipoInstituicao { get; set; }
        public SecretariaParametro Secretaria { get; set; }
    }

    public class TipoInstituicaoParametro
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }

    public class SecretariaParametro
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }

}
